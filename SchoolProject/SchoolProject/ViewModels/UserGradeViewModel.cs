using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.ViewModels
{
    public class UserGradeViewModel
    {
        public ApplicationUser User { get; set; }
        public List<Grade> Grades{ get; set; }
        public string UserId { get; set; }
        public int Mark { get; set; }
        public string Subject { get; set; }
    }
}