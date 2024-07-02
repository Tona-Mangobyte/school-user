using AutoMapper;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Application.Mediator.StudentMediator.Commands;
using SchoolUser.Application.Mediator.TeacherMediator.Commands;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using SchoolUser.Application.Mediator.UserMediator.Queries;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Infrastructure.Data;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Services
{
    public class UserServices : IUserServices
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly IPasswordServices _passwordServices;
        private readonly IConfiguration _configuration;
        private readonly string _pepper;
        private readonly int _iteration;
        private readonly IMailServices _mailServices;
        private readonly IRegisterServices _registerServices;
        private readonly IClassCategoryServices _classCategoryServices;
        private readonly ITeacherServices _teacherServices;
        private readonly IStudentServices _studentServices;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly IValidationConstants _validationConstants;
        private readonly IGeneralUseConstants _generalUseConstants;
        private readonly string EntityName = "User";
        private readonly DBContext _dbContext;

        public UserServices(ISender sender, IMapper mapper, IPasswordServices passwordServices, IConfiguration configuration, IMailServices mailServices, IRegisterServices registerServices, IMemoryCache memoryCache, IReturnValueConstants returnValueConstants, IValidationConstants validationConstants, DBContext dbContext, IClassCategoryServices classCategoryServices, IGeneralUseConstants generalUseConstants, ITeacherServices teacherServices, IStudentServices studentServices)
        {
            _sender = sender;
            _mapper = mapper;
            _passwordServices = passwordServices;
            _configuration = configuration;
            _pepper = _configuration.GetValue<string>("Password:Pepper");
            _iteration = _configuration.GetValue<int>("Password:Iteration");
            _mailServices = mailServices;
            _registerServices = registerServices;
            _classCategoryServices = classCategoryServices;
            _returnValueConstants = returnValueConstants;
            _validationConstants = validationConstants;
            _generalUseConstants = generalUseConstants;
            _dbContext = dbContext;
            _teacherServices = teacherServices;
            _studentServices = studentServices;
        }

        public async Task<IEnumerable<GetUserResponseDto>> GetAllUsersService()
        {
            var listOfUsers = await _sender.Send(new GetAllUsersQuery());
            var dtoList = new List<GetUserResponseDto>();

            foreach (var user in listOfUsers)
            {
                var dto = _mapper.Map<GetUserResponseDto>(user);
                dtoList.Add(dto);
            }

            return dtoList;
        }

        public async Task<PaginatedUsersResponseDto> GetPaginatedUsersService(int pageNumber, int pageSize, string? roleTitle)
        {
            if (!string.IsNullOrWhiteSpace(roleTitle))
            {
                if (!_validationConstants.ValidPositions.Contains(roleTitle))
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, "Role"));
                }
            }

            var (listOfUsers, totalUsers) = await _sender.Send(new GetPaginatedUsersQuery(pageNumber, pageSize, roleTitle));
            var dtoList = new List<GetUserResponseDto>();

            foreach (var user in listOfUsers)
            {
                var dto = _mapper.Map<GetUserResponseDto>(user);
                dtoList.Add(dto);
            }

            PaginatedUsersResponseDto paginatedUsers = new PaginatedUsersResponseDto()
            {
                TotalUsers = totalUsers,
                ReturnedUsers = dtoList.Count,
                PaginationList = dtoList
            };

            return paginatedUsers;
        }

        public async Task<GetUserResponseDto> GetUserByIdService(Guid id)
        {
            var user = await _sender.Send(new GetUserByIdQuery(id));

            if (user == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            return _mapper.Map<GetUserResponseDto>(user);
        }

        public async Task<string> UpdateUserService(Guid id, GetUserRequestDto getUserDto)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                bool isUserUpdated = false;
                bool isUserChildUpdated = false;

                var existing = await _sender.Send(new GetUserByIdQuery(id));

                if (existing == null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
                }

                if (getUserDto.ClassCategoryId != null)
                {
                    await _classCategoryServices.CheckIdValidityService((Guid)getUserDto.ClassCategoryId);
                }

                foreach (var ur in existing.Roles!)
                {
                    switch (ur)
                    {
                        case "student":
                            var isStudentUpdated = await _studentServices.UpdateStudent(getUserDto, existing.Student);
                            if (isStudentUpdated)
                            {
                                isUserChildUpdated = true;
                            }
                            break;
                        case "teacher":
                            var isTeacherUpdated = await _teacherServices.UpdateTeacher(getUserDto, existing.Teacher);
                            if (isTeacherUpdated)
                            {
                                isUserChildUpdated = true;
                            }
                            break;
                        default:
                            isUserChildUpdated = true;
                            break;
                    }
                }

                if (existing.FullName != getUserDto.FullName ||
                existing.EmailAddress != getUserDto.EmailAddress ||
                existing.MobileNumber != getUserDto.MobileNumber ||
                existing.BirthDate != getUserDto.DateOfBirth.ToString(_generalUseConstants.DateFormat) ||
                existing.Gender != getUserDto.Gender)
                {
                    var toUpdate = _mapper.Map<User>(getUserDto);
                    toUpdate.Id = existing.Id;
                    toUpdate.BirthDate = getUserDto.DateOfBirth.ToString(_generalUseConstants.DateFormat);
                    toUpdate.Age = _registerServices.CalculateAge(getUserDto.DateOfBirth);

                    isUserUpdated = await _sender.Send(new UpdateUserCommand(toUpdate));
                }

                if (!isUserUpdated && !isUserChildUpdated)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, EntityName));
                }

                await transaction.CommitAsync();
                return string.Format(_returnValueConstants.SUCCESSFUL_UPDATE, EntityName);
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

        public async Task<string> DeleteUserService(Guid id)
        {
            var result = await _sender.Send(new DeleteUserCommand(id));

            if (!result)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_DELETE, EntityName));
            }

            return string.Format(_returnValueConstants.SUCCESSFUL_DELETE, EntityName);
        }

        public async Task<string> VerifyAccountService(VerifyAccountDto verifyAccountDto)
        {
            var existingUser = await _sender.Send(new GetUserByEmailQuery(verifyAccountDto.EmailAddress));

            if (existingUser == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            if (existingUser.IsConfirmedEmail)
            {
                throw new BusinessRuleException("Code Invalid!");
            }

            if (DateTime.Now > existingUser.VerificationExpiration)
            {
                throw new BusinessRuleException("Code Expired!");
            }

            if (verifyAccountDto.VerificationNumber != existingUser.VerificationNumber)
            {
                throw new BusinessRuleException("Wrong verification number.");
            }

            existingUser.IsConfirmedEmail = true;
            existingUser.VerificationNumber = "Completed";

            var verResult = await _sender.Send(new VerifyUserCommand(existingUser));

            if (verResult)
            {
                MailDataDto mailData = new MailDataDto()
                {
                    EmailToId = existingUser.EmailAddress,
                    EmailToName = existingUser.FullName,
                    EmailSubject = string.Format(_returnValueConstants.SUCCESSFUL_VERIFICATION),
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
                        <p><b>Greetings, {existingUser.FullName}</b></p>
                        <p>Your email verification is completed. Please proceed to log-in</p>
                    </body>
                </html>
                "
                };

                bool mailResult = _mailServices.SendMailService(mailData);

                if (!mailResult)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.EMAIL_SENDING_ERROR, "verification email!"));
                }
            }

            return string.Format(_returnValueConstants.SUCCESSFUL_VERIFICATION);
        }

        public async Task<string> ChangePasswordService(ChangePasswordDto changePasswordDto)
        {
            var existingUser = await _sender.Send(new GetUserByEmailQuery(changePasswordDto.EmailAddress));

            if (existingUser == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            if (!existingUser.IsConfirmedEmail)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ACCOUNT_NOT_VERIRIED));
            }

            var passwordHash = _passwordServices.CreatePasswordHashService(changePasswordDto.OldPassword, existingUser.PasswordSalt, _pepper, _iteration);

            if (existingUser.PasswordHash != passwordHash)
            {
                throw new BusinessRuleException("Old Password is Wrong!");
            }

            existingUser.PasswordSalt = _passwordServices.GenerateSaltService();
            existingUser.PasswordHash = _passwordServices.CreatePasswordHashService(changePasswordDto.NewPassword, existingUser.PasswordSalt, _pepper, _iteration);

            var changeResult = await _sender.Send(new ChangePasswordCommand(existingUser));

            if (changeResult)
            {
                MailDataDto mailData = new MailDataDto()
                {
                    EmailToId = existingUser.EmailAddress,
                    EmailToName = existingUser.FullName,
                    EmailSubject = string.Format(_returnValueConstants.SUCCESSFUL_CHANGE_PASSWORD),
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
                        <p><b>Greetings, {existingUser.FullName}</b></p>
                        <p>Here is the your new password: {changePasswordDto.NewPassword}</p>
                        <p>Please call the hotline if you do not perform this.</p>
                    </body>
                </html>
                "
                };

                bool mailResult = _mailServices.SendMailService(mailData);

                if (!mailResult)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.EMAIL_SENDING_ERROR, "new password!"));
                }
            }

            return string.Format(_returnValueConstants.SUCCESSFUL_CHANGE_PASSWORD);
        }

        public async Task<string> ResetPasswordService(ResetPasswordDto resetPasswordDto)
        {
            var existingUser = await _sender.Send(new GetUserByEmailQuery(resetPasswordDto.EmailAddress));

            if (existingUser == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            if (!existingUser.IsConfirmedEmail)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ACCOUNT_NOT_VERIRIED));
            }

            var randomPassword = _passwordServices.CreateRandomPasswordService();
            existingUser.PasswordSalt = _passwordServices.GenerateSaltService();
            existingUser.PasswordHash = _passwordServices.CreatePasswordHashService(randomPassword, existingUser.PasswordSalt, _pepper, _iteration);

            var changeResult = await _sender.Send(new ChangePasswordCommand(existingUser));

            if (changeResult)
            {
                MailDataDto mailData = new MailDataDto()
                {
                    EmailToId = existingUser.EmailAddress,
                    EmailToName = existingUser.FullName,
                    EmailSubject = string.Format(_returnValueConstants.SUCCESSFUL_RESET_PASSWORD),
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
                        <p><b>Greetings, {existingUser.FullName}</b></p>
                        <p>Here is the your temporary password: {randomPassword}</p>
                        <p>Please change to your unique password for better security.</p>
                    </body>
                </html>
                "
                };


                bool result = _mailServices.SendMailService(mailData);

                if (!result)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.EMAIL_SENDING_ERROR, "reset password!"));
                }
            }
            else
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_RESET_PASSWORD, EntityName));
            }

            return string.Format(_returnValueConstants.SUCCESSFUL_RESET_PASSWORD);
        }

    }
}