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
    public class ResultController : ApiController
    {
        private MyDbContext _context;

        public ResultController()
        {
            _context = new MyDbContext();
        }

        // Get /api/Result
        public IEnumerable<ResultDto> GetResults()
        {
            return _context.Results.ToList().Select(Mapper.Map<Result, ResultDto>);
        }

        // Get /api/Result/Id
        public ResultDto GetResult(int id)
        {
            var result = _context.Results.SingleOrDefault(c => c.Id == id);

            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Result, ResultDto>(result);
        }

        // Post /api/Result
        [HttpPost] 
        public ResultDto AddResult(ResultDto resultDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            }
            var result = Mapper.Map<ResultDto, Result>(resultDto);
            _context.Results.Add(result);
            _context.SaveChanges();

            resultDto.Id = result.Id;

            return resultDto;
        } 

        // Put /api/Result/Id
        [HttpPut]
        public void EditResult(int id, ResultDto resultDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var resultInDb = _context.Results.Single(c => c.Id == resultDto.Id);

            if(resultInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<ResultDto, Result>(resultDto, resultInDb);
 
            _context.SaveChanges();
        }
    }
}
