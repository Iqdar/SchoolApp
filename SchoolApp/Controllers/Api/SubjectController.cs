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
    public class SubjectController : ApiController
    {

        private MyDbContext _context;

        public SubjectController()
        {
            _context = new MyDbContext();
        }


        // Get /api/Subjects
        public IEnumerable<Subject> GetSubjects()
        {
            return _context.Subjects.ToList();
        }

        // Get /api/Subject/Id
        public Subject GetSubject(int id)
        {
            var subject = _context.Subjects.SingleOrDefault(c => c.Id == id);

            if (subject == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return subject;
        }

        // Post /api/Subject
        [HttpPost]
        public Subject AddSubject(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            }
            _context.Subjects.Add(subject);
            _context.SaveChanges();

            return subject;
        }

        // Put /api/Subject/Id
        [HttpPut]
        public void EditSubject(int id, Subject subject)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var subjectInDb = _context.Subjects.Single(c => c.Id == id);

            if (subjectInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            subjectInDb.Name = subject.Name;
            subjectInDb.CoursCode = subject.CoursCode;
            subjectInDb.StageId = subject.StageId;
            subjectInDb.TeacherId = subject.TeacherId;
            _context.SaveChanges();
        }
    }
}
