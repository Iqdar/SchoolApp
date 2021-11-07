using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolApp.Models;
using System.Data.Entity;

namespace SchoolApp.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Result> Results { get; set; }

    }
}