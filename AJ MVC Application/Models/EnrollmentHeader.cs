using System.ComponentModel.DataAnnotations;

namespace AJ_MVC_Application.Models
{
    public class EnrollmentHeader
    {
        [Key]
        [Required]
        public string ENRHStudID { get; set; }
        [Required]
        public string ENRHStudDateEnroll { get; set;}
        [Required]
        [StringLength(15)]
        public string ENRHStudSchoolYear { get;}
        [Required]
        [StringLength(30)]
        public string ENRHStudEncoder { get; set; }
        [Required]
        public int ENRHStudTotalUnits { get; set; }
        [Required]
        [StringLength(2)]
        public string ENRHStudStatud { get; set; }
    }
}
