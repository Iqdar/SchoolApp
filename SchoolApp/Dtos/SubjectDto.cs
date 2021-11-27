using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolApp.Dtos
{
    public class SubjectDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CoursCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public int StageId { get; set; }
    }
}