using System.ComponentModel.DataAnnotations.Schema;

namespace lab2MVC.Models
{
    public class instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ImageURl { get; set; }
        public int Salary { get; set; }

        public string Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }


        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
