using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Models.ViewModels
{
    public class StageViewModel
    {
        public Stage Stage { get; set; }
        public IEnumerable<Teacher> Teacher { get; set; }
    }
}