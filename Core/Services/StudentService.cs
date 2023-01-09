using AutoMapper;
using Core.Entities;
using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IStudentService
    {
        public void CreateStudent(StudentDto student);

        public List<StudentDto> GetAllStudents();

        public void UpdateStudent(StudentDto student);

        public void DeleteStudent(int id);
    }

    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;
        private readonly IMapper _mapper;

        public StudentService(IRepository<Student> repository,
            IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }

        public void CreateStudent(StudentDto _student){

            Student student = new Student();
            student.Id = _student.Id;
            student.Name = _student.Name;
            student.Email = _student.Email;
            student.Nrc = _student.Nrc;
            student.Address = _student.Address;
            student.Image= _student.Image;
            student.Dob = _student.Dob;
            student.PhNo= _student.PhNo;
            student.CreatedOn = DateTime.Now;
            student.Deleted = 0;
            _repository.Create(student);
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public List<StudentDto> GetAllStudents()
        {
            var students = _repository.GetAll();
            return _mapper.Map<List<StudentDto>>(students);
        }

        public void UpdateStudent(StudentDto student)
        {
            throw new NotImplementedException();
        }
    }
}
