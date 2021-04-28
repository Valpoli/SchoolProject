using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;
using SchoolProject.Models;
using SchoolProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SchoolDbContext _context;

        public UserInfoController(UserManager<ApplicationUser> userManager, SchoolDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Grade()
        {
            return View();
        }
        public async Task<IActionResult> Fee()
        {
            return View();
        }
        public async Task<IActionResult> Classes()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserGrade()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User cannot be found";
                return View("NotFound");
            }

            UserGradeViewModel model = await GetUserGradeViewModelFromUser(user);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserGrade([Bind("UserId,Mark,Subject")] UserGradeViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                Grade grade = new Grade();
                grade.Mark = viewModel.Mark;
                grade.Subject = viewModel.Subject;
                var user = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == viewModel.UserId);

                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User cannot be found";
                    return View("NotFound");
                }
                grade.User = user;
                _context.Grades.Add(grade);
                await _context.SaveChangesAsync();

                viewModel = await GetUserGradeViewModelFromUser(user);

            }
            return View(viewModel);
        }

        private async Task<UserGradeViewModel> GetUserGradeViewModelFromUser(ApplicationUser user)
        {
            UserGradeViewModel viewModel = new UserGradeViewModel();
            viewModel.User = user;
            List<Grade> grades = await _context.Grades.Where(m => m.User == user).ToListAsync();
            viewModel.Grades = grades;
            return viewModel;

        }

    }
}
