﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolApp.Models;
using SchoolApp.Models.ViewModels;
using System.Data.Entity;

namespace SchoolApp.Controllers
{
    public class StageController : Controller
    {

        private MyDbContext _context;

        public StageController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Stage

        public ActionResult Save(Stage stage)
        {
            if (!ModelState.IsValid)
            {
                var teachers = _context.Teachers.ToList();
                var viewModel = new StageViewModel
                {
                    Teacher = teachers,
                    Stage = stage
                };
                return View("StageForm", viewModel);

            }
            if (stage.Id == 0)
            {
                _context.Stages.Add(stage);
            }
            else
            {
                var stageInDb = _context.Stages.Single(c => c.Id == stage.Id);

                stageInDb.ClassStage = stage.ClassStage;
                stageInDb.Section = stage.Section;
                stageInDb.TeacherId = stage.TeacherId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Stage");
        }

        public ActionResult New()
        {
            var teachers = _context.Teachers.ToList();
            var stage = new Stage();

            var viewModel = new StageViewModel
            {
                Teacher = teachers,
                Stage = stage
            };
            return View("StageForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var teachers = _context.Teachers.ToList();
            var stage = _context.Stages.SingleOrDefault(c => c.Id == id);
            var viewModel = new StageViewModel
            {
                Teacher = teachers,
                Stage = stage
            };
            return View("StageForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var stage = _context.Stages.SingleOrDefault(c => c.Id == id);
            var students = _context.Students.Where(c => c.StageId == id);
            var viewModel = new StageViewModel
            {
                Student = students,
                Stage = stage
            };
            return View(viewModel);
        }

        public ActionResult Index()
        {
            var stages = _context.Subjects.Include(d => d.Teacher).ToList();
            return View(stages);
        }
    }
}