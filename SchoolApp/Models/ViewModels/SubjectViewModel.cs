using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Models.ViewModels
{
    public class SubjectViewModel
    {

        public Subject Subject { get; set; }
        public IEnumerable<Stage> Stage { get; set; }
        public IEnumerable<Teacher> Teacher { get; set; }
    }
}