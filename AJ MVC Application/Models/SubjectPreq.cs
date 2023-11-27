using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJ_MVC_Application.Models
{
    public class SubjectPreq
    {
        [Required]
        [Key]
        public string SubjCode { get; set; }

        [Required]
        public string SubjPreCode{ get; set; }
        [Required]
        public string SubjCategory { get; set; }
    }
}
