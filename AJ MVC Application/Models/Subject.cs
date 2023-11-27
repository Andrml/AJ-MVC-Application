using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJ_MVC_Application.Models
{
    public class Subject
    {
        [Required]
        [Key]
        [StringLength(15)]
        public string SubjectCode { get; set; } //columns

        [Required]
        [StringLength(40)]
        public string SubjectDescription { get; set; }

        [Required]
        public int SubjectUnits { get; set; }
        [Required]
        public int SubjectRegOffering { get; set; }
        [Required]
        [Key]
        [StringLength(3)]
        public string SubjectCategory { get; set; }
        [Required]
        [StringLength(2)]
        public string SubjectStatus { get; set; }
        [Key]
        [Required]
        [StringLength(10)]
        public string SubjectCourseCode { get; set; }


        [Required]
        [StringLength(10)]
        public string SubjectCurrCode { get; set; }

    }
}
