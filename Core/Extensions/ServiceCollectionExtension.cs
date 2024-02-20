using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Core.Mappings;
using Core.Controllers;
using Core.Entities;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Core.Utilities;
using UnitOfWork;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Core.Helper;

namespace Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddExtService(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddSingleton<IPasswordHelper,PasswordHelper>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.AccessDeniedPath = "/Auth/AccessDenied";

                    options.Cookie = new CookieBuilder
                    {
                        SameSite = SameSiteMode.Strict,
                        SecurePolicy = CookieSecurePolicy.Always,
                        IsEssential = true,
                        HttpOnly = true
                    };
                    options.Cookie.Name = "Authentication";
                });

            services.AddScoped<IUnitOfWork<Context>, UnitOfWork<Context>>();

            services.AddSingleton<IAppHandler, AppHandler>();

            services.AddScoped<DbContext, Context>();

            /*
            services.AddScoped<IRepository<Course>, Repository<Course>>();
            services.AddScoped<IRepository<Student>, Repository<Student>>();
            */

            services.AddScoped<ICourseController, CourseController>();
            services.AddScoped<IStudentController, StudentController>();
            services.AddScoped<IAuthController, AuthController>();

            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
