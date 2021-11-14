using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolApp.Models;
using SchoolApp.Models.ViewModels;
using System.Data.Entity;

namespace SchoolApp.Controllers
{
    public class SubjectController : Controller
    {
        private MyDbContext _context;

        public SubjectController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Subject

        [HttpPost]
        public ActionResult Save(Subject subject)
        {
            if (subject.Id == 0)
            {
                _context.Subjects.Add(subject);
            }
            else
            {
                var subjectsInDb = _context.Subjects.Single(c => c.Id == subject.Id);

                subjectsInDb.Name = subject.Name;
                subjectsInDb.CoursCode = subject.CoursCode;
                subjectsInDb.StageId = subject.StageId;
                subjectsInDb.TeacherId = subject.TeacherId;
            }

            _context.SaveChanges(); 
            return RedirectToAction("Index", "Subject");
        }

        public ActionResult New()
        {
            var teachers = _context.Teachers.ToList();
            var stages = _context.Stages.ToList();
            var subject = new Subject();
            var viewModel = new SubjectViewModel
            {
                Subject = subject,
                Teacher = teachers,
                Stage = stages
            };

            return View("SubjectForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var teachers = _context.Teachers.ToList();
            var stages = _context.Stages.ToList();
            var subject = _context.Subjects.SingleOrDefault(c => c.Id == id);
            var viewModel = new SubjectViewModel
            {
                Teacher = teachers,
                Stage = stages,
                Subject = subject
            };
            return View("SubjectForm", viewModel);
        }

        public ActionResult Index()
        {
            var subjects = _context.Subjects.Include(c => c.Stage).Include(d => d.Teacher).ToList();
            return View(subjects);
        }
    }
}