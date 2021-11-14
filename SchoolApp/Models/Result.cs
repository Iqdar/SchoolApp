using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolApp.Models
{
    public class Result
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Term { get; set; }
        
        public Student Student { get; set; }
        [Required]
        public int StudentId { get; set; }
        
        public Stage Stage { get; set; }
        [Required]
        public int StageId { get; set; }
        [Required]
        public double Percentage { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}