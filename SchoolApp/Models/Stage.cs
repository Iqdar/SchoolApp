using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class Stage
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ClassStage { get; set; }
        [Required]
        public char Section { get; set; }
        public Teacher Teacher { get; set; }
        [Required]
        public int TeacherId { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}