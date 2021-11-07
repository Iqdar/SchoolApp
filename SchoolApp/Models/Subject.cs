using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class Subject
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CoursCode { get; set; }
        [Required]
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public Stage Stage { get; set; }
        [Required]
        public int StageId { get; set; }
    }
}