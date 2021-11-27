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
    public class StudentController : ApiController
    {
        private MyDbContext _context;

        public StudentController()
        {
            _context = new MyDbContext();
        }
        // Get /api/Students
        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        // Get /api/Student/Id
        public Student GetStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(c => c.Id == id);

            if (student == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return student;
        }

        // Post /api/Student
        [HttpPost]
        public Student AddStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            }
            _context.Students.Add(student);
            _context.SaveChanges();

            return student;
        }

        // Put /api/Student/Id
        [HttpPut]
        public void EditStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var studentInDb = _context.Students.Single(c => c.Id == id);

            if (studentInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            studentInDb.Name = student.Name;
            studentInDb.FName = student.FName;
            studentInDb.Address = student.Address;
            studentInDb.DateOfBirth = student.DateOfBirth;
            studentInDb.StageId = student.StageId;

            _context.SaveChanges();
        }
    }
}
