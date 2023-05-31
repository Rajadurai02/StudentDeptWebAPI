using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDeptWebAPI.Models
{
    public class StudentDeptContext: DbContext
    {
        public StudentDeptContext(DbContextOptions<StudentDeptContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding some data to data base
            modelBuilder.Entity<Department>().HasData(new Department()
            {
                DepartmentID = 101,
                DepartmentName = "Computer Science & Engineering"
            });

            modelBuilder.Entity<Department>().HasData(new Department()
            {
                DepartmentID = 102,
                DepartmentName = "Mechanical Engineering"
            });


            modelBuilder.Entity<Student>().HasData(new Student()
            {
                StudentID = 1001,
                StudentName = "Arun",
                Course = "B.E",
                Specialization = "Computer Science",
                Percentage = 70.5,
                DepartmentID = 101
            });

            modelBuilder.Entity<Student>().HasData(new Student()
            {
                StudentID = 1002,
                StudentName = "Balaji",
                Course = "B.E",
                Specialization = "Mechanical",
                Percentage = 78.5,
                DepartmentID = 102
            });
        }
    }
}
