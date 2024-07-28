using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LAP.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20,ErrorMessage ="must be less than 20 characters")]
        [MinLength(2, ErrorMessage = "must be more than 2 characters")]
        public string Name { get; set; }
        [Range(18, 60)]
        public int Age { get; set; }

        public string? Image { get; set; }

        [ForeignKey("Department")]
        [Required]
        [Range(1,4)]
        public int DepatmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
