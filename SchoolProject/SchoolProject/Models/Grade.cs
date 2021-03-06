using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [Range(0, 20)]
        public int Mark { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Subject { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
