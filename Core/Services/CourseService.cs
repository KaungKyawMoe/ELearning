using AutoMapper;
using Core.Entities;
using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICourseService
    {
        List<CourseDto> GetCourses();

        void CreateCourse(CourseDto course);
    }
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _repository;
        private readonly IMapper _mapper;

        public CourseService(IRepository<Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CreateCourse(CourseDto _course)
        {
            var course = new Course();
            course.Id = Guid.NewGuid().ToString();
            course.Name= _course.Name;
            course.Description= _course.Description;
            course.Fees= _course.Fees;
            course.StartDate= _course.StartDate;
            course.EndDate= _course.EndDate;
            course.CreatedOn = DateTime.Now;
            course.Deleted = 0;

            _repository.Create(course).Wait();
        }

        public List<CourseDto> GetCourses()
        {
            var courses = _repository.GetAll().ToList();
            var courseDtos = _mapper.Map<List<CourseDto>>(courses);
            return courseDtos;
        }
    }
}
