using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
