using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2MVC.Models
{
    public class Trainee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string ImageURl { get; set; }
        public string Address { get; set; }

        public int grade { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<crsResult> CrsResults { get; set; }

    }
}
