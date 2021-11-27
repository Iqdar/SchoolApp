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
    public class StageController : ApiController
    {
        private MyDbContext _context;

        public StageController()
        {
            _context = new MyDbContext();
        }

        // Get /api/Stages
        public IEnumerable<Stage> GetStages()
        {
            return _context.Stages.ToList();
        }

        // Get /api/Stage/Id
        public Stage GetStage(int id)
        {
            var stage = _context.Stages.SingleOrDefault(c => c.Id == id);

            if (stage == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return stage;
        }

        // Post /api/Stage
        [HttpPost]
        public Stage AddStage(Stage stage)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            }
            _context.Stages.Add(stage);
            _context.SaveChanges();

            return stage;
        }

        // Put /api/Stage/Id
        [HttpPut]
        public void EditStage(int id, Stage stage)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var StageInDb = _context.Stages.Single(c => c.Id == id);

            if (StageInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            StageInDb.ClassStage = stage.ClassStage;
            StageInDb.Section = stage.Section;
            StageInDb.TeacherId = stage.TeacherId;

            _context.SaveChanges();
        }
    }
}
