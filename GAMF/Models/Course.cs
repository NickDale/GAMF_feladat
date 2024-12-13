using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAMF.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // ez az id nem automatikusan generált, hanem kézzel megadott lesz
        public int CourseId { get; set; }

        [Display(Name = "Név")]
        public string Title { get; set;}

        [Display(Name = "Kredit")]
        public int Credits { get; set;}

        [Display(Name = "Felvételek")]
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
