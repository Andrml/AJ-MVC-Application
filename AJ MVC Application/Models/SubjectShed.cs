using System.ComponentModel.DataAnnotations;

namespace AJ_MVC_Application.Models
{
    public class SubjectShed
    {
        [Required]
        [Key]
        [StringLength(8)]
        public string SubjEDPCode{ get; set; }
        [Required]
        [StringLength(15)]
        public string SubjCode { get; set; }
        [Required]
        public string SubjStartTime { get; set; }
        [Required]
        public string SubjEndTime { get; set;}
        [Required]
        [StringLength(3)]
        public string SubjDays { get; set; }
        [Required]
        [StringLength(3)]
        public int SubjRoom { get;}
        [Required]
        public int SubjMaxSize { get; set; }
        [Required]
        public int SubjClassSize { get; set;}
        [Required]
        [StringLength(3)]
        public string SubjStatus { get;set;}
        [Required]
        [StringLength(3)]
        public string SubjXM { get; set;}
        [Required]
        [StringLength(3)]
        public string SubjSection { get; set;}
        [Required]
        public int SubjSchoolYear { get; set;}
    }
}
