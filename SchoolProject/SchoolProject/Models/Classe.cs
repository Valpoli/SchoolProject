using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    public class Classe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Subject { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Day { get; set; }
        [Range(1, 24)]
        [Required]
        public int Hour { get; set; }
        public bool Attendance { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
