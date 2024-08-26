using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreCRUD.Models
{
    public class Student
    {

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Gender { get; set; }
    }
}
