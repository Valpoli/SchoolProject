using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.ViewModels
{
    public class UserClasseViewModel
    {
        public ApplicationUser User { get; set; }
        public List<Classe> Classes { get; set; }
        public string UserId { get; set; }
        public string Subject { get; set; }
        public string Day { get; set; }
        public int Hour { get; set; }
        public bool Attendance { get; set; }
        public IList<string> Roles { get; set; }
    }
}
