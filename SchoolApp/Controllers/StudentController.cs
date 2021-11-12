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
    public class StudentController : Controller
    {
        private MyDbContext _context;

        public StudentController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Student

        public ActionResult Save(Student student)
        {
            if(student.Id == 0)
            {
                _context.Students.Add(student);
            }
            else
            {
                var studentInDb = _context.Students.Single(c => c.Id == student.Id);

                studentInDb.Name = student.Name;
                studentInDb.FName = student.FName;
                studentInDb.Address = student.Address;
                studentInDb.DateOfBirth = student.DateOfBirth;
                studentInDb.StageId = student.StageId;


            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
        public ActionResult New()
        {
            var stages = _context.Stages.ToList();
            return View("StudentForm", stages);
        }
        public ActionResult Edit(int id)
        {
            var stages = _context.Stages.ToList();
            var student = _context.Students.SingleOrDefault(c => c.Id == id);

            var viewModel = new StudentViewModel
            {
                Stage = stages,
                Student = student
            };
            return View("StudentForm",viewModel);
        }
        public ActionResult Details(int id)
        {
            var student = _context.Students.Where(c => c.Id == id);
            var results = _context.Results.Where(c => c.StudentId == id).ToList();
            var viewModel = new ResultViewModel
            {
                Student = student,
                Result = results
            };
            return View(viewModel);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}