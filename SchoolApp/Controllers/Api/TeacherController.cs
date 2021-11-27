using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolApp.Models;
using SchoolApp.Dtos;
using AutoMapper;

namespace SchoolApp.Controllers.Api
{
    public class TeacherController : ApiController
    {

        private MyDbContext _context;

        public TeacherController()
        {
            _context = new MyDbContext();
        }


        // Get /api/Teachers
        public IEnumerable<Teacher> GetTeachers()
        {
            return _context.Teachers.ToList();
        }

        // Get /api/Teacher/Id
        public Teacher GetTeacher(int id)
        {
            var teacher = _context.Teachers.SingleOrDefault(c => c.Id == id);

            if (teacher == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return teacher;
        }

        // Post /api/Teacher
        [HttpPost]
        public Teacher AddTeacher(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            }
            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return teacher;
        }

        // Put /api/Teacher/Id
        [HttpPut]
        public void EditTeacher(int id, Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var teacherInDb = _context.Teachers.Single(c => c.Id == id);

            if (teacherInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            teacherInDb.Name = teacher.Name;
            teacherInDb.Address = teacher.Address;
            teacherInDb.DateOfBirth = teacher.DateOfBirth;
            teacherInDb.DateJoined = teacher.DateJoined;
            _context.SaveChanges();
        }
    }
}
