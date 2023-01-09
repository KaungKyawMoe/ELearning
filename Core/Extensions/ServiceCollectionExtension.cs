using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Mappings;
using Core.Controllers;
using Core.Entities;
using Core.Repositories;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Core.Utilities;
using UnitOfWork;

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

            services.AddScoped<IUnitOfWork<e_learningContext>, UnitOfWork<e_learningContext>>();

            services.AddSingleton<IAppHandler, AppHandler>();

            services.AddScoped<DbContext, e_learningContext>();

            /*
            services.AddScoped<IRepository<Course>, Repository<Course>>();
            services.AddScoped<IRepository<Student>, Repository<Student>>();
            */

            services.AddScoped<ICourseController, CourseController>();
            services.AddScoped<IStudentController, StudentController>();

            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}
