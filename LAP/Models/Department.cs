using System.ComponentModel.DataAnnotations;

namespace LAP.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
      
        public string Name { get; set; }


        public virtual List<Student>? Students { get; set; }
    }
}
