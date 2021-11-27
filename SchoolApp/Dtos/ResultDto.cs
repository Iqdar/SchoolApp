using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Dtos
{
    public class ResultDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Term { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int StageId { get; set; }
        [Required]
        public double Percentage { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}