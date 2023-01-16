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
using UnitOfWork;

namespace Core.Services
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetCourses();

        Task<bool> CreateCourse(CourseDto course);

        Task<CourseDto> GetCourse(String id);

        Task<bool> UpdateCourse(CourseDto _course);
    }
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<e_learningContext> _unitOfWork;

        public CourseService(
            IUnitOfWork<e_learningContext> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateCourse(CourseDto _course)
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

            //_repository.Create(course).Wait();
            return _unitOfWork.GetRepository<Course>().Create(course).Result;
        }

        public async Task<List<CourseDto>> GetCourses()
        {
            //var courses = _repository.GetAll();
            var courses = _unitOfWork.GetRepository<Course>().GetAll().Result;
            var courseDtos = _mapper.Map<List<CourseDto>>(courses);
            return courseDtos;
        }

        public async Task<CourseDto> GetCourse(String id)
        {
            //var course = _repository.GetById(id).Result;
            var course = _unitOfWork.GetRepository<Course>().GetById(id).Result;
            var courseDto = _mapper.Map<CourseDto>(course);
            return courseDto;
        }

        public async Task<bool> UpdateCourse(CourseDto _course)
        {
            //var course = _repository.GetById(_course.Id).Result;
            var course = _unitOfWork.GetRepository<Course>().GetById(_course.Id).Result;
            course.Name = _course.Name;
            course.Description = _course.Description;
            course.Fees = _course.Fees;
            course.StartDate = _course.StartDate;
            course.EndDate = _course.EndDate;
            course.UpdatedOn = DateTime.Now;
            course.Deleted = 0;

            //_repository.Update(course).Wait();
            return _unitOfWork.GetRepository<Course>().Update(course).Result;
        }
    }
}
