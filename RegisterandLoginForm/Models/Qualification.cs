using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegisterandLoginForm.Models
{
    public class Qualification
    {
        [Key]
        public int QualificationId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public string University { get; set; }

        [Required]
        public int YearOfPassing { get; set; }

        [Required]
        public decimal Percentage { get; set; }

        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
