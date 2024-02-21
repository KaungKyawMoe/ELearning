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

        Task<ResultModel<object>> CreateCourse(CourseDto course);

        Task<CourseDto> GetCourse(String id);

        Task<ResultModel<object>> UpdateCourse(CourseDto _course);
    }
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<Context> _unitOfWork;

        public CourseService(
            IUnitOfWork<Context> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultModel<object>> CreateCourse(CourseDto _course)
        {
            try
            {
                var course = new Course();
                course.Id = Guid.NewGuid().ToString();
                course.Name = _course.Name;
                course.Description = _course.Description;
                course.Image = _course.Image ?? course.Image;
                course.Fees = _course.Fees;
                course.StartDate = _course.StartDate;
                course.EndDate = _course.EndDate;
                course.CreatedOn = DateTime.Now;
                course.Deleted = 0;

                //_repository.Create(course).Wait();
                await _unitOfWork.GetRepository<Course>().Create(course);

                await _unitOfWork.GetRepository<Course>().CommitAsync();

                return new ResultModel<Object>()
                {
                    Data = course,
                    IsSuccess = true,
                    Message = "Data is created successfully"
                };
            }
            catch (Exception ex)
            {
                throw;
            }
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

        public async Task<ResultModel<object>> UpdateCourse(CourseDto _course)
        {
            try
            {
                //var course = _repository.GetById(_course.Id).Result;
                var course = _unitOfWork.GetRepository<Course>().GetById(_course.Id).Result;
                course.Name = _course.Name;
                course.Description = _course.Description;
                course.Image = _course.Image ?? course.Image;
                course.Fees = _course.Fees;
                course.StartDate = _course.StartDate;
                course.EndDate = _course.EndDate;
                course.UpdatedOn = DateTime.Now;
                course.Deleted = 0;

                //_repository.Update(course).Wait();
                await _unitOfWork.GetRepository<Course>().Update(course);

                await _unitOfWork.GetRepository<Course>().CommitAsync();

                return new ResultModel<Object>()
                {
                    Data = course,
                    IsSuccess = true,
                    Message = "Data is updated successfully"
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
