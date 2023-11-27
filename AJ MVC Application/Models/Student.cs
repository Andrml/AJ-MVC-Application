using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJ_MVC_Application.Models
{
    public class Student
    {
        [Key]
        [Required]
        [StringLength(10)]
        public string StudentId { get; set; }
        [Required]
        [StringLength(20)]
        public string StudentFName { get; set; }
        [Required]
        [StringLength(15)]
        public string StudentLName { get; set; }
        [Required]
        [StringLength(15)]
        public string StudentMName { get; set; }
        [Required]
        [StringLength(10)]
        public string StudentCourse { get; set; }

        [Required]
        public int? StudentYear { get; set; }
        [Required]
        [StringLength(15)]
        public string StudentRemarks { get; set; }
      
        [StringLength(2)]
        [DefaultValue("AC")]
        public string StudentStatus { get; set;}

    }
}
