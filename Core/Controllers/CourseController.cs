﻿using Core.Entities;
using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Controllers
{

    public interface ICourseController
    {
        List<CourseDto> GetCourses();

        void CreateCourse(CourseDto _course);
    }

    public class CourseController : ICourseController
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public List<CourseDto> GetCourses()
        {
            return _courseService.GetCourses();
        }

        public void CreateCourse(CourseDto _course)
        {
            _courseService.CreateCourse(_course);
        }
    }
}
