using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace lab2MVC.Models
{
    public class ITIContext:DbContext
    {
        public ITIContext():base() { }

        
        //class Mapping Table 
        //create class Course in DB
        public DbSet<Course> Course { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<instructor> instructor { get; set; }
        public DbSet<crsResult> crsResult { get; set; }

        // connect to Data base Connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MVC;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }

        // Enter Data on tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Deparment
            modelBuilder.Entity<Department>().HasData(new Department() { Id =1, Name ="CS", ManagerName ="Mazen"});
            modelBuilder.Entity<Department>().HasData(new Department() { Id = 2, Name = "AI", ManagerName = "Ali" });
            modelBuilder.Entity<Department>().HasData(new Department() { Id = 3, Name = "IS", ManagerName = "Noha" });

            //Trainee 

            modelBuilder.Entity<Trainee>().HasData(new Trainee()
            {
                Id = 1,
                Name = "Ahmed",
                ImageURl = "man3.jpg",
              grade= 4,
                Address = "Tanan",
                DepartmentId = 1,
            });
            modelBuilder.Entity<Trainee>().HasData(new Trainee()
            {
                Id = 2,
                Name = "Hager",
                ImageURl = "girl1.jpg",
                grade = 5,
                Address = "NewYourk",
                DepartmentId = 2,
            });
            modelBuilder.Entity<Trainee>().HasData(new Trainee()
            {
                Id = 3,
                Name = "Soha",
                ImageURl = "girl5.jpg",
                grade = 6,
                Address = "Turkia",
                DepartmentId = 3,
            });

            //Course 
            modelBuilder.Entity<Course>().HasData(new Course() { Id = 1, Name = "C#",
                Degree = 100,
                MinDegree = 60,
                DepartmentId=1,

            });
            modelBuilder.Entity<Course>().HasData(new Course()
            {
                Id = 2,
                Name = "GIS",
                Degree = 100,
                MinDegree = 60,
                DepartmentId = 3,

            });
            modelBuilder.Entity<Course>().HasData(new Course()
            {
                Id = 3,
                Name = "ML",
                Degree = 100,
                MinDegree = 60,
                DepartmentId = 2,

            });
            //crsResult 
            modelBuilder.Entity<crsResult>().HasData(new crsResult()
            {Id=1,degree=80,CourseId=1,TraineeId=1, });

            modelBuilder.Entity<crsResult>().HasData(new crsResult()
            { Id = 2, degree = 50, CourseId = 2, TraineeId = 2, });

            modelBuilder.Entity<crsResult>().HasData(new crsResult()
            { Id = 3, degree = 100, CourseId = 3, TraineeId = 3, });


            // instructor 
            modelBuilder.Entity<instructor>().HasData(new instructor()
            {
                Id = 1,
                Name = "Tamer",
                ImageURl = "man4.jpg",
                Salary = 15000,
                Address = "Cairo",
                DepartmentId = 1,
                CourseId = 1
            });

            modelBuilder.Entity<instructor>().HasData(new instructor()
            {
                Id = 2,
                Name = "Jasmen",
                ImageURl = "girl2.jpg",
                Salary = 20000,
                Address = "Giza",
                DepartmentId = 2,
                CourseId = 3
            });
            modelBuilder.Entity<instructor>().HasData(new instructor()
            {
                Id = 3,
                Name = "Sama",
                ImageURl = "girl4.jpg",
                Salary = 4000,
                Address = "Alex",
                DepartmentId = 1,
                CourseId = 2
            });
            modelBuilder.Entity<instructor>().HasData(new instructor()
            {
                Id = 4,
                Name = "Maha",
                ImageURl = "girl3.jpg",
                Salary = 8000,
                Address = "Koria",
                DepartmentId = 3,
                CourseId = 1,
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
