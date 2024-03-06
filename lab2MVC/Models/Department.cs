using System.ComponentModel.DataAnnotations;

namespace lab2MVC.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; } //PK Identity
        public string Name { get; set; }
        public string ManagerName { get; set; }

        public List<instructor> Instructors { get; set; }
        public List<Trainee> Trainees { get; set; }
        public List<Course> Courses { get; set; }
    }
}
