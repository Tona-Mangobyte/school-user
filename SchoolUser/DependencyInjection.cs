using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.CircuitBreaker;
using Polly.RateLimiting;
using Polly.Retry;
using SchoolUser.Application.DTOs;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.Interfaces.UnitOfWorks;
using SchoolUser.Application.Middleware;
using SchoolUser.Contract.Constants.Main;
using SchoolUser.Application.Validations;
using SchoolUser.Domain.Services;
using SchoolUser.Infrastructure.Data;
using SchoolUser.Infrastructure.Repositories;
using SchoolUser.Infrastructure.UnitOfWorks;

public static class DependencyInjection
{

    public static void AddControllerClass(this IServiceCollection services)
    {
        services.AddControllers()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
    }

    public static void AddSwaggerAndSecurity(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "JWT Authentication",
                Description = "Enter a valid JWT bearer token",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {securityScheme, new string[] {} }
            });
        });
    }

    public static void AuthenticationAndAuthorization(this IServiceCollection services, string issuer, string audience, SymmetricSecurityKey key)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = key,
                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddAuthorization();
    }

    public static void AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DBContext>((IServiceProvider serviceProvider, DbContextOptionsBuilder options) =>
        {
            var env = serviceProvider.GetRequiredService<IWebHostEnvironment>();

            options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });

            options.EnableSensitiveDataLogging(env.IsDevelopment()); // Enable sensitive data logging only in development
            if (env.IsDevelopment())
            {
                options.LogTo(Console.WriteLine); // Log SQL commands to the console only in development
            }

        });

        services.AddScoped<IDbContextTransaction>(sp =>
        {
            using var scope = sp.CreateScope();
            var scopedServiceProvider = scope.ServiceProvider;
            return scopedServiceProvider.GetService<DBContext>()!.Database.BeginTransaction();
        });

    }

    public static void AddExternalLibraries(this IServiceCollection services, string connectionString)
    {
        services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(connectionString))
                .AddHangfireServer()
                .AddSingleton<HangfireServices>()
                .AddMvc();

        services.AddMediatR(Assembly.GetExecutingAssembly())
                .AddAutoMapper(typeof(Program).Assembly)
                .AddMemoryCache();

    }

    public static void AddServicesLifetime(this IServiceCollection services)
    {
        services.AddScoped<IUserUnitOfWork, UserUnitOfWork>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserRoleRepository, UserRoleRepository>()
                .AddScoped<IStudentRepository, StudentRepository>()
                .AddScoped<ITeacherRepository, TeacherRepository>()
                .AddScoped<IBatchRepository, BatchRepository>()
                .AddScoped<IClassCategoryRepository, ClassCategoryRepository>()
                .AddScoped<ISubjectRepository, SubjectRepository>()
                .AddScoped<IClassSubjectRepository, ClassSubjectRepository>()
                .AddScoped<IClassStreamRepository, ClassStreamRepository>()
                .AddScoped<IClassSubjectStudentRepository, ClassSubjectStudentRepository>()
                .AddScoped<IClassSubjectTeacherRepository, ClassSubjectTeacherRepository>();

        services.AddScoped<IUserServices, UserServices>()
                .AddScoped<IRoleServices, RoleServices>()
                .AddScoped<IUserRoleServices, UserRoleServices>()
                .AddScoped<IRegisterServices, RegisterServices>()
                .AddScoped<IPasswordServices, PasswordServices>()
                .AddScoped<ITokenServices, TokenServices>()
                .AddScoped<IMailServices, MailServices>()
                .AddScoped<IAuthServices, AuthServices>()
                .AddScoped<IHeaderServices, HeaderService>()
                .AddScoped<IValidationServices, ValidationServices>()
                .AddScoped<IBatchServices, BatchServices>()
                .AddScoped<IClassCategoryServices, ClassCategoryServices>()
                .AddScoped<ISubjectServices, SubjectServices>()
                .AddScoped<IClassSubjectServices, ClassSubjectServices>()
                .AddScoped<IClassStreamServices, ClassStreamServices>()
                .AddScoped(typeof(ICacheServices<>), typeof(CacheServices<>))
                .AddScoped<IStudentServices, StudentServices>()
                .AddScoped<ITeacherServices, TeacherServices>();

        services.AddScoped<IValidationConstants, ValidationConstants>()
                .AddScoped<IReturnValueConstants, ReturnValueConstants>()
                .AddScoped<IGeneralUseConstants, GeneralUseConstants>();

        services.AddScoped<IValidator<RoleDto>, AddRoleValidator>()
                .AddScoped<IValidator<AddUserRequestDto>, AddUserValidator>()
                .AddScoped<IValidator<GetUserRequestDto>, GetUserValidator>()
                .AddScoped<IValidator<VerifyAccountDto>, VerifyAccountValidator>()
                .AddScoped<IValidator<ChangePasswordDto>, ChangePasswordValidator>()
                .AddScoped<IValidator<RefreshJwtTokenDto>, RefreshJwtTokenValidator>()
                .AddScoped<IValidator<ResetPasswordDto>, ResetPasswordValidator>()
                .AddScoped<IValidator<UpdateStudentsDto>, UpdateStudentsDtoValidator>();

    }

    public static void ConfigureApiBehaviors(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var errors = context.ModelState
                .Where(e => e.Value?.Errors.Count > 0)
                .SelectMany(x => x.Value?.Errors!)
                .Select(x => x.ErrorMessage).ToArray();

                var errorResponse = new { Errors = errors };
                return new BadRequestObjectResult(errorResponse);
            };
        });
    }

    public static void AddResilenceStrategy(this IServiceCollection services)
    {
        services.AddResiliencePipeline("my-pipeline", builder =>
        {
            builder.AddRetry(new RetryStrategyOptions())
           .AddCircuitBreaker(new CircuitBreakerStrategyOptions())
           .AddTimeout(TimeSpan.FromSeconds(45))
           .AddRateLimiter(new RateLimiterStrategyOptions())
           .AddConcurrencyLimiter(100, 50);
        });
    }

    public static void ConfigurePersistenceScoped(this WebApplication application)
    {
        using (var scope = application.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<DBContext>();
            dbContext.Database.Migrate();
        }
    }

    public static void ConfigureHangfireSettings(this WebApplication application)
    {
        application.MapHangfireDashboard();
        application.Services.GetRequiredService<HangfireServices>().ConfigureHangfire();
    }

    public static void ConfigureMiddleware(this WebApplication application)
    {
        application.UseMiddleware<ExceptionHandlingMiddleware>()
        .UseMiddleware<TransactionHandlingMiddleware>();
    }

}