using AutoMapper;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.Interfaces.UnitOfWorks;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.StudentMediator.Commands;
using SchoolUser.Application.Mediator.TeacherMediator.Commands;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using SchoolUser.Application.Mediator.UserMediator.Queries;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Infrastructure.Data;
using SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Commands;
using SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Commands;

namespace SchoolUser.Domain.Services
{
    public class RegisterServices : IRegisterServices
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly DBContext _dbContext;
        private readonly IPasswordServices _passwordServices;
        private readonly ITokenServices _tokenServices;
        private readonly IConfiguration _configuration;
        private readonly string _pepper;
        private readonly int _iteration;
        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly IMailServices _mailServices;
        private readonly IRoleServices _roleServices;
        private readonly IUserRoleServices _userRoleServices;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly IGeneralUseConstants _generalUseConstants;
        private readonly IStudentServices _studentServices;
        private readonly ITeacherServices _teacherServices;
        private const string entityName = "User";

        public RegisterServices(ISender sender, IMapper mapper, IPasswordServices passwordServices, ITokenServices tokenServices, IConfiguration configuration, IUserUnitOfWork userUnitOfWork, IMailServices mailServices, IRoleServices roleServices, IUserRoleServices userRoleServices, IReturnValueConstants returnValueConstants, IGeneralUseConstants generalUseConstants, DBContext dbContext, IStudentServices studentServices, ITeacherServices teacherServices)
        {
            _sender = sender;
            _mapper = mapper;
            _passwordServices = passwordServices;
            _tokenServices = tokenServices;
            _configuration = configuration;
            _pepper = _configuration.GetValue<string>("Password:Pepper")!;
            _iteration = _configuration.GetValue<int>("Password:Iteration");
            _userUnitOfWork = userUnitOfWork;
            _mailServices = mailServices;
            _roleServices = roleServices;
            _userRoleServices = userRoleServices;
            _returnValueConstants = returnValueConstants;
            _generalUseConstants = generalUseConstants;
            _dbContext = dbContext;
            _studentServices = studentServices;
            _teacherServices = teacherServices;
        }

        public async Task<AddUserResponseDto?> CreateUserService(AddUserRequestDto addUserRequestDto, string? tokenHeader)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var existingUser = await _sender.Send(new GetUserByEmailQuery(addUserRequestDto.EmailAddress));
                string creatorName = "System";
                string creatorEmail = "system@email.com";
                bool isUserChildCreated = false;
                User createdUser = new User();

                if (!tokenHeader.IsNullOrEmpty())
                {
                    string? cleanedToken = tokenHeader!.Replace("Bearer ", "");
                    var workingAdmin = await _sender.Send(new GetUserByJwtTokenQuery(cleanedToken));
                    creatorName = workingAdmin!.FullName;
                    creatorEmail = workingAdmin.EmailAddress;
                }

                if (existingUser != null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, $"User with email {addUserRequestDto.EmailAddress}"));
                }

                var newUser = _mapper.Map<User>(addUserRequestDto);

                newUser.Id = Guid.NewGuid();
                newUser.IsConfirmedEmail = false;
                newUser.BirthDate = addUserRequestDto.DateOfBirth.ToString(_generalUseConstants.DateFormat);
                newUser.Age = CalculateAge(addUserRequestDto.DateOfBirth);

                var randomPassword = _passwordServices.CreateRandomPasswordService();
                newUser.PasswordSalt = _passwordServices.GenerateSaltService();
                newUser.PasswordHash = _passwordServices.CreatePasswordHashService(randomPassword, newUser.PasswordSalt, _pepper, _iteration);

                newUser.VerificationNumber = _tokenServices.CreateVerificationTokenService(6);
                newUser.VerificationExpiration = DateTime.Now.AddDays(7);

                newUser.CreatedBy = creatorName;
                newUser.CreatedAt = DateTime.Now.ToString(_generalUseConstants.DateFormat);
                newUser.TokenExpiration = DateTime.Now;

                newUser.Roles = new List<string>
                {
                    addUserRequestDto.RegisterFor
                };

                var validRoles = await _roleServices.CheckExistingRolesService(newUser.Roles);

                createdUser = await _sender.Send(new AddUserCommand(newUser));

                if (createdUser == null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, entityName));
                }

                switch (addUserRequestDto.RegisterFor)
                {
                    case "student":
                        StudentRequestDto studentRequestDto = new StudentRequestDto()
                        {
                            UserId = newUser.Id,
                            EntranceYear = addUserRequestDto.EntranceYear,
                            EstimatedExitYear = addUserRequestDto.EstimatedExitYear,
                            RealExitYear = "N/A",
                            ExitReason = "N/A",
                            ClassCategoryId = addUserRequestDto.ClassCategoryId,
                            ClassSubjectIds = addUserRequestDto.ClassSubjectIds
                        };
                        isUserChildCreated = await _studentServices.CreateStudent(studentRequestDto);
                        break;
                    case "teacher":
                        TeacherRequestDto teacherRequestDto = new TeacherRequestDto()
                        {
                            UserId = newUser.Id,
                            ServiceStatus = addUserRequestDto.ServiceStatus,
                            IsAvailable = addUserRequestDto.IsAvailable,
                            ClassCategoryId = addUserRequestDto.ClassCategoryId,
                            ClassSubjectIds = addUserRequestDto.ClassSubjectIds
                        };
                        isUserChildCreated = await _teacherServices.CreateTeacher(teacherRequestDto);
                        break;
                    default:
                        break;
                }

                if (isUserChildCreated)
                {
                    await _userRoleServices.CreateUserRoleService(createdUser!.Id, validRoles!);
                    await transaction.CommitAsync();
                }

                var response = _mapper.Map<AddUserResponseDto>(createdUser);
                response.Password = randomPassword;

                MailDataDto mailData = new MailDataDto()
                {
                    EmailToId = createdUser.EmailAddress,
                    EmailToName = createdUser.FullName,
                    EmailCcId = creatorEmail,
                    EmailCcName = creatorName,
                    EmailSubject = "Registration Successful",
                    EmailBody = $@"
                <html>
                    <head>
                        <style>
                            body {{
                                font-family: 'Arial', sans-serif;
                                line-height: 1.6;
                                margin: 20px;
                            }}
                            b {{
                                color: #000000;
                            }}
                            p {{
                                margin-bottom: 10px;
                            }}
                        </style>
                    </head>
                    <body>
                        <p><b>Greetings, {createdUser.FullName}</b></p>
                        <p>Here are the details of the registered account:</p>
                        <ul>
                            <li><b>Fullname:</b> {createdUser.FullName}</li>
                            <li><b>Email Address:</b> {createdUser.MobileNumber}</li>
                            <li><b>Date Of Birth:</b> {createdUser.BirthDate}</li>
                            <li><b>Gender:</b> {createdUser.Gender}</li>
                            <li><b>Age:</b> {createdUser.Age}</li>
                            <li><b>Verification Number:</b> {newUser.VerificationNumber}</li>
                            <li><b>Password:</b> {randomPassword}</li>
                        </ul>
                        <p>Please verify the account within 48 hours after the registration is completed.</p>
                    </body>
                </html>
                "
                };

                bool result = _mailServices.SendMailService(mailData);

                if (!result)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.EMAIL_SENDING_ERROR, "Verification Email"));
                }

                return response;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
            finally
            {
                transaction.Dispose();
            }

        }

        public int CalculateAge(DateTime dateOfBirth)
        {
            int currentYear = DateTime.Now.Year;
            int age = currentYear - dateOfBirth.Year;
            return age;
        }

    }
}