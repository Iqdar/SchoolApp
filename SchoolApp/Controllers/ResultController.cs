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
    public class ResultController : Controller
    {
        private MyDbContext _context;

        public ResultController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Result
        public ActionResult Save(Result result)
        {
            if(result.Id == 0)
            {
                _context.Results.Add(result);
            }
            else
            {
                var resultInDb = _context.Results.Single(c => c.Id == result.Id);

                resultInDb.Term = result.Term;
                resultInDb.Date = result.Date;
                resultInDb.Stage = result.Stage;
                resultInDb.StageId = result.StageId;
                resultInDb.StudentId = result.StudentId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Result");
        }
        public ActionResult New()
        {
            var students = _context.Students.ToList();
            var stages = _context.Stages.ToList();
            var result = new Result();
            
            var viewModel = new ResultViewModel
            {
                Student = students,
                Result2 = result,
                Stage = stages
            };
            return View("ResultForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var students = _context.Students.ToList();
            var stages = _context.Stages.ToList();
            var result = _context.Results.SingleOrDefault(c => c.Id == id);
            var viewModel = new ResultViewModel
            {
                Result2 = result,
                Student = students,
                Stage = stages
            };
            return View("ResultForm", viewModel);
        }

        public ActionResult Index()
        {
            var results = _context.Results.Include(c => c.Student).Include(d => d.Stage).ToList();
            return View(results);
        }


    }
}