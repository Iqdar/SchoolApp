using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolApp.Models;
using System.Data.Entity;

namespace SchoolApp.Controllers
{
    public class TeacherController : Controller
    {
        private MyDbContext _context;

        public TeacherController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Teacher
        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return View("TeacherForm", teacher);
            }
            if (teacher.Id == 0)
            {
                _context.Teachers.Add(teacher);
            }
            else
            {
                var teacherInDb = _context.Teachers.Single(c => c.Id == teacher.Id);

                teacherInDb.Name = teacher.Name;
                teacherInDb.Address = teacher.Address;
                teacherInDb.DateOfBirth = teacher.DateOfBirth;
                teacherInDb.DateJoined = teacher.DateJoined;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Teacher");
        }

        public ActionResult New()
        {
            var teacher = new Teacher();
            return View("TeacherForm", teacher);
        }

        public ActionResult Edit(int id)
        {
            var teacher = _context.Teachers.SingleOrDefault(c => c.Id == id);
            if(teacher == null)
            {
                return HttpNotFound();
            }
            return View("TeacherForm", teacher);
        }

        public ActionResult Index()
        {
            var teachers = _context.Teachers.ToList();
            return View(teachers);
        }
    }
}