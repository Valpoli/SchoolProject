using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.ViewModels
{
    public class UserFeeViewModel
    {
        public ApplicationUser User { get; set; }
        public List<Fee> Fees { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public bool Paid { get; set; }
    }
}
