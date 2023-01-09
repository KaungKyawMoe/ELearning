using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Controllers
{

    public interface IStudentController
    {
        public List<StudentDto> GetAllStudents();

        public void Create(StudentDto student);

        public void Update(StudentDto student);

        public void Delete(int id);
    }

    public class StudentController : IStudentController
    {

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public void Create(StudentDto student)
        {
            student.Id = Guid.NewGuid().ToString();
            student.Image = Encoding.ASCII.GetBytes(student.ImageSrc);
            _studentService.CreateStudent(student);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<StudentDto> GetAllStudents()
        {
            return _studentService.GetAllStudents();
        }

        public void Update(StudentDto student)
        {
            throw new NotImplementedException();
        }
    }
}
