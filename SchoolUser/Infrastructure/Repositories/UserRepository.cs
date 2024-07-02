using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.ErrorHandlings;
using System.Globalization;

namespace SchoolUser.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _dbContext;
        private readonly ICacheServices<User> _cacheServices;
        private readonly IRegisterServices _registerServices;
        private const string cacheKey_GetUserById = "GetUserById";
        private const string cacheKey_GetPaginatedUsers = "GetPaginatedUser";
        private const string student_constant = "student";
        private const string teacher_constant = "teacher";
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly IGeneralUseConstants _generalUseConstants;
        private const string EntityName = "User";

        public UserRepository(DBContext dbContext, ICacheServices<User> cacheServices, IReturnValueConstants returnValueConstants, IRegisterServices registerServices, IGeneralUseConstants generalUseConstants)
        {
            _dbContext = dbContext;
            _cacheServices = cacheServices;
            _returnValueConstants = returnValueConstants;
            _registerServices = registerServices;
            _generalUseConstants = generalUseConstants;
        }

        private IQueryable<User> GetUsersQuery()
        {
            return _dbContext.UserTable!
                .AsNoTracking()
                .AsSplitQuery()
                .Select(u => new User
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    EmailAddress = u.EmailAddress,
                    MobileNumber = u.MobileNumber,
                    BirthDate = u.BirthDate,
                    Gender = u.Gender,
                    Age = u.Age,
                    Roles = u.UserRoles!.Select(ur => ur.Role!.Title).ToList(),
                    Student = u.UserRoles!.Any(ur => ur.Role!.Title == student_constant) ? new Student
                    {
                        Id = u.Student.Id,
                        EntranceYear = u.Student.EntranceYear,
                        EstimatedExitYear = u.Student.EstimatedExitYear,
                        RealExitYear = u.Student.RealExitYear,
                        ExitReason = u.Student.ExitReason,
                        UserId = u.Student.UserId,
                        ClassSubjects = u.Student.ClassSubjectStudents == null ? new List<ClassSubject>() : u.Student.ClassSubjectStudents.Select(css => css.ClassSubject!).ToList(),
                        ClassCategory = u.Student.ClassCategory,
                        ClassCategoryId = u.Student.ClassCategoryId,
                    } : null,
                    Teacher = u.UserRoles!.Any(ur => ur.Role!.Title == teacher_constant) ? new Teacher
                    {
                        Id = u.Teacher.Id,
                        ServiceStatus = u.Teacher.ServiceStatus,
                        IsAvailable = u.Teacher.IsAvailable,
                        UserId = u.Teacher.UserId,
                        ClassSubjects = u.Teacher.ClassSubjectTeachers == null ? new List<ClassSubject>() : u.Teacher.ClassSubjectTeachers.Select(css => css.ClassSubject!).ToList(),
                        ClassCategory = u.Teacher.ClassCategory,
                        ClassCategoryId = u.Teacher.ClassCategoryId,
                    } : null,
                });
        }

        public async Task<IEnumerable<User?>> GetAllAsync()
        {
            return await GetUsersQuery()
                .OrderBy(u => u.FullName)
                .ToListAsync();
        }

        public async Task<(IEnumerable<User?>, int)> GetPaginatedUsersAsync(int pageNumber, int pageSize, string? roleTitle)
        {
            int totalUsers = await _dbContext.UserTable!.CountAsync();
            int totalPages = (int)Math.Ceiling(totalUsers / (double)pageSize);

            if (pageNumber < 1 || pageNumber > totalPages)
            {
                return (Enumerable.Empty<User?>(), 0);
            }

            if (pageNumber < totalPages)
            {
                var next_cacheKey = $"{cacheKey_GetPaginatedUsers}_{pageNumber + 1}_{pageSize}";

                if (!string.IsNullOrWhiteSpace(roleTitle))
                {
                    next_cacheKey = $"{next_cacheKey}_{roleTitle}";
                }

                await GetPaginatedUserList(next_cacheKey, pageNumber + 1, pageSize, roleTitle);
            }

            var current_cacheKey = $"{cacheKey_GetPaginatedUsers}_{pageNumber}_{pageSize}";

            if (!string.IsNullOrWhiteSpace(roleTitle))
            {
                current_cacheKey = $"{current_cacheKey}_{roleTitle}";
            }

            var cachedObject = _cacheServices.TryGetObjectFromCache(current_cacheKey, typeof(IEnumerable<User?>));

            if (cachedObject != null)
            {
                return ((IEnumerable<User?>)cachedObject, totalPages);
            }

            return await GetPaginatedUserList(current_cacheKey, pageNumber, pageSize, roleTitle);
        }

        private async Task<(IEnumerable<User>, int)> GetPaginatedUserList(string cacheKey, int pageNumber, int pageSize, string? roleTitle)
        {
            List<User>? paginatedUsers = new List<User>();

            if (string.IsNullOrWhiteSpace(roleTitle))
            {
                paginatedUsers = await GetUsersQuery().ToListAsync();
            }
            else
            {
                paginatedUsers = await GetUsersQuery()
                    .Where(u => u.Roles!.Contains(roleTitle))
                    .ToListAsync();
            }

            int totalUsers = paginatedUsers.Count;

            paginatedUsers = paginatedUsers
                    .OrderBy(u => u.FullName)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

            _cacheServices.SetCacheObject(cacheKey, paginatedUsers);

            return (paginatedUsers, totalUsers);
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            var cacheKey = $"{cacheKey_GetUserById}_{id}";
            var cachedObject = _cacheServices.TryGetObjectFromCache(cacheKey, typeof(User));

            if (cachedObject != null)
            {
                return (User?)cachedObject;
            }
            else
            {
                var user = await GetUsersQuery()
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (user != null)
                {
                    _cacheServices.SetCacheObject(cacheKey, user!);
                }

                return user;
            }
        }

        public async Task<User?> GetByJwtTokenAsync(string jwtToken)
        {
            return await _dbContext.UserTable!
                .Where(u => u.AccessToken == jwtToken)!
                .Select(u => new User
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    EmailAddress = u.EmailAddress,
                    IsConfirmedEmail = u.IsConfirmedEmail,
                    MobileNumber = u.MobileNumber,
                    BirthDate = u.BirthDate,
                    Gender = u.Gender,
                    Age = u.Age,
                    PasswordSalt = u.PasswordSalt,
                    PasswordHash = u.PasswordHash,
                    VerificationNumber = u.VerificationNumber,
                    VerificationExpiration = u.VerificationExpiration,
                    AccessToken = u.AccessToken,
                    RefreshToken = u.RefreshToken,
                    TokenExpiration = u.TokenExpiration,
                    CreatedBy = u.CreatedBy,
                    CreatedAt = u.CreatedAt,
                    Roles = u.UserRoles!.Select(ur => ur.Role!.Title).ToList(),
                    Student = null,
                    Teacher = null
                })
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.UserTable!
                .Where(u => u.EmailAddress == email)!
                .Select(u => new User
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    EmailAddress = u.EmailAddress,
                    IsConfirmedEmail = u.IsConfirmedEmail,
                    MobileNumber = u.MobileNumber,
                    BirthDate = u.BirthDate,
                    Gender = u.Gender,
                    Age = u.Age,
                    PasswordSalt = u.PasswordSalt,
                    PasswordHash = u.PasswordHash,
                    VerificationNumber = u.VerificationNumber,
                    VerificationExpiration = u.VerificationExpiration,
                    AccessToken = u.AccessToken,
                    RefreshToken = u.RefreshToken,
                    TokenExpiration = u.TokenExpiration,
                    CreatedBy = u.CreatedBy,
                    CreatedAt = u.CreatedAt,
                    Roles = u.UserRoles!.Select(ur => ur.Role!.Title).ToList(),
                    Student = null,
                    Teacher = null
                })
                .FirstOrDefaultAsync();
        }

        public async Task<User?> CreateAsync(User user)
        {
            await _dbContext.UserTable!.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var existing = await _dbContext.UserTable!.FirstOrDefaultAsync(u => u.Id == user.Id);

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            existing.FullName = user.FullName;
            existing.EmailAddress = user.EmailAddress;
            existing.MobileNumber = user.MobileNumber;
            existing.BirthDate = user.BirthDate;
            existing.Age = user.Age;
            existing.Gender = user.Gender;

            int result = await _dbContext.SaveChangesAsync();

            if (result < 1)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
            }

            var cacheKey = $"{cacheKey_GetUserById}_{user!.Id}";
            _cacheServices.RemoveCacheObject(cacheKey);

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _dbContext.UserTable!.FindAsync(id);

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            _dbContext.UserTable.Remove(existing);
            int result = await _dbContext.SaveChangesAsync();

            if (result < 1)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_DELETE, EntityName));
            }

            var cacheKey = $"{cacheKey_GetUserById}_{existing!.Id}";
            _cacheServices.RemoveCacheObject(cacheKey);

            return true;
        }

        public async Task AutoUpdateUserAgeAsync()
        {
            try
            {
                var userList = await _dbContext.UserTable!.ToListAsync();

                if (userList.Any())
                {
                    foreach (var user in userList)
                    {
                        DateTime today = DateTime.Today;
                        DateTime birthdate = DateTime.ParseExact(user.BirthDate, _generalUseConstants.DateFormat, CultureInfo.InvariantCulture);

                        if (today.Day == birthdate.Day && today.Month == birthdate.Month)
                        {
                            user.Age = _registerServices.CalculateAge(birthdate);
                        }
                    }

                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, ex, EntityName));
            }
        }

        public async Task DeleteInactiveUsersAsync()
        {
            DateTime thresholdYears = DateTime.Now.AddYears(-5);

            var inactiveUsers = await _dbContext.UserTable!.Where(u => u.TokenExpiration < thresholdYears).ToListAsync();

            try
            {
                _dbContext.UserTable!.RemoveRange(inactiveUsers);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to delete inactive users.", ex);
            }
        }

        public async Task DeleteUnregisteredUsersAsync()
        {
            DateTime thresholdDays = DateTime.Now;

            var unregisteredUsers = await _dbContext.UserTable!.Where(u => u.IsConfirmedEmail == false && u.TokenExpiration < thresholdDays).ToListAsync();

            try
            {
                _dbContext.UserTable!.RemoveRange(unregisteredUsers);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to delete unregistered users.", ex);
            }
        }

        public async Task<bool> VerifyUserAsync(User user)
        {
            var existing = await _dbContext.UserTable!.FirstOrDefaultAsync(u => u.Id == user.Id);

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            existing.IsConfirmedEmail = user.IsConfirmedEmail;
            existing.VerificationNumber = user.VerificationNumber;

            int result = await _dbContext.SaveChangesAsync();

            if (result < 1)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_VERIFICATION, EntityName));
            }

            var cacheKey = $"{cacheKey_GetUserById}_{user!.Id}";
            _cacheServices.RemoveCacheObject(cacheKey);

            return true;
        }

        public async Task<bool> ChangePasswordAsync(User user)
        {
            var existing = await _dbContext.UserTable!.FirstOrDefaultAsync(u => u.Id == user.Id);

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            existing.PasswordHash = user.PasswordHash;
            existing.PasswordSalt = user.PasswordSalt;

            var result = await _dbContext.SaveChangesAsync();

            if (result < 1)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CHANGED_PASSWORD, EntityName));
            }

            var cacheKey = $"{cacheKey_GetUserById}_{user!.Id}";
            _cacheServices.RemoveCacheObject(cacheKey);

            return true;
        }

        public async Task<User?> UpdateTokenAsync(User user)
        {
            var existing = await _dbContext.UserTable!.FirstOrDefaultAsync(u => u.Id == user.Id);

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            existing.AccessToken = user.AccessToken;
            existing.RefreshToken = user.RefreshToken;
            existing.TokenExpiration = user.TokenExpiration;

            var result = await _dbContext.SaveChangesAsync();

            if (result < 1)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, "Token"));
            }

            var cacheKey = $"{cacheKey_GetUserById}_{user!.Id}";
            _cacheServices.RemoveCacheObject(cacheKey);

            return existing;
        }
    }
}