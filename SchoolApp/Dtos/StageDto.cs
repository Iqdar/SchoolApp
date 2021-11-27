using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Dtos
{
    public class StageDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ClassStage { get; set; }
        [Required]
        public char Section { get; set; }
        [Required]
        public int TeacherId { get; set; }


    }
}