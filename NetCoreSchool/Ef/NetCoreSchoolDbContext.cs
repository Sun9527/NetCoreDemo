using Microsoft.EntityFrameworkCore;
using NetCoreSchool.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreSchool.Ef
{
    public class NetCoreSchoolDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Achievement>().ToTable("Achievement");
            modelBuilder.Entity<Course>().ToTable("Course");

            base.OnModelCreating(modelBuilder);
        }
    }
}
