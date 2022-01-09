using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LearningRazoPages.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required, DisplayName("Student Name")]
        public string studentName { get; set; }
        [DisplayName("Student Address")]
        public string studentAddress { get; set; }
    }
}
