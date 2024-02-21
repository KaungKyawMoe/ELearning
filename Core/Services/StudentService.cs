using AutoMapper;
using Core.Entities;
using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Core.Services
{
    public interface IStudentService
    {
        public Task<ResultModel<Object>> CreateStudent(StudentDto student);

        public Task<List<StudentDto>> GetAllStudents();

        public Task<StudentDto> GetStudentById(string id);

        public Task<ResultModel<Object>> UpdateStudent(StudentDto student);

        public Task DeleteStudent(int id);
    }

    public class StudentService : IStudentService
    {
        //private readonly IRepository<Student> _repository;
        private readonly IUnitOfWork<Context> _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(
            IUnitOfWork<Context> unitOfWork,
            //<Student> repository,
            IMapper mapper){
            //_repository = repository;
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultModel<Object>> CreateStudent(StudentDto _student){

            try
            {
                Student student = new Student();
                student.Id = _student.Id;
                student.Name = _student.Name;
                student.Email = _student.Email;
                student.Nrc = _student.Nrc;
                student.Address = _student.Address;
                student.Image = _student.Image ?? student.Image;
                student.Dob = _student.Dob;
                student.PhNo = _student.PhNo;
                student.CreatedOn = DateTime.Now;
                student.Deleted = 0;

                //_repository.Create(student).Wait();
                await _unitOfWork.GetRepository<Student>().Create(student);

                await _unitOfWork.GetRepository<Student>().CommitAsync();

                return new ResultModel<Object>()
                {
                    Data = student,
                    IsSuccess = true,
                    Message = "Data is created successfully"
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StudentDto>> GetAllStudents()
        {
            //var students = _repository.GetAll();
            var students = _unitOfWork.GetRepository<Student>().GetAll().Result;
            return _mapper.Map<List<StudentDto>>(students);
        }

        public async Task<StudentDto> GetStudentById(string id)
        {
            //var student = _repository.GetById(id).Result;
            var student = _unitOfWork.GetRepository<Student>().GetById(id).Result;
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<ResultModel<Object>> UpdateStudent(StudentDto _student)
        {
            try
            {
                //var student = _repository.GetById(_student.Id).Result;
                var student = _unitOfWork.GetRepository<Student>().GetById(_student.Id).Result;
                student.Id = _student.Id;
                student.Name = _student.Name;
                student.Email = _student.Email;
                student.Nrc = _student.Nrc;
                student.Address = _student.Address;
                student.Image = _student.Image ?? student.Image;
                student.Dob = _student.Dob;
                student.PhNo = _student.PhNo;
                student.UpdatedOn = DateTime.Now;
                student.Deleted = 0;

                //_repository.Update(student).Wait();
                var result = _unitOfWork.GetRepository<Student>().Update(student).Result;

                await _unitOfWork.CommitAsync();

                return new ResultModel<Object>()
                {
                    Data = student,
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
