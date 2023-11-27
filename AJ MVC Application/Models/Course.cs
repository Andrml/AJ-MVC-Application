using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJ_MVC_Application.Models
{
    public class Course
    {
        [Key]
        [Required]
        [StringLength(10)]
        public string CourseCode { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
