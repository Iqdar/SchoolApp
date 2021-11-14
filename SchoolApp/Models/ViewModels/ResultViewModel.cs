using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Models.ViewModels
{
    public class ResultViewModel
    {
        public Result Result2 { get; set; }
        public Student Student2 { get; set; }
        public IEnumerable<Result> Result { get; set; }
        public IEnumerable<Stage> Stage { get; set; }
        public IEnumerable<Student> Student { get; set; }
    }
}