using Microsoft.AspNetCore.Authorization;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SchoolDbContext _context;

        public UserInfoController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager, SchoolDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }


        [HttpGet]
        [Authorize(Roles = "Administrator, Teacher, Student")]
        public async Task<IActionResult> UserGrade()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User cannot be found";
                return View("~/Views/Account/Login.cshtml");
            }

            UserGradeViewModel model = await GetUserGradeViewModelFromUser(user);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Teacher, Student")]
        public async Task<IActionResult> UserGradeWithID(string userId)
        {
            ViewBag.userId = userId;

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User cannot be found";
                return View("NotFound");
            }

            UserGradeViewModel model = await GetUserGradeViewModelFromUser(user);
            return View("UserGrade", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> UserGrade([Bind("UserId,Mark,Subject")] UserGradeViewModel viewModel)
        {
            if (ModelState.IsValid)
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
            IList<string> userRoles = await _userManager.GetRolesAsync(user);
            viewModel.Roles = userRoles;
            return viewModel;

        }

        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> EditUserGrade(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGrade = await _context.Grades.FindAsync(id);
            if (userGrade == null)
            {
                return NotFound();
            }
            return View("EditUserGrade", userGrade);
        }

        private bool GradeExists(string id)
        {
            return _context.Grades.Any(e => e.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> EditUserGrade(string id, [Bind("Id,Mark,Subject")] Grade grade)
        {
            if (id != grade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradeExists(grade.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var users = _userManager.Users;
                return View("~/Views/Administration/ListUsers.cshtml", users);
            }
            return View(grade);
        }

        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> DeleteUserGrade(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> DeleteConfirmedUserGrade(string Id)
        {
            var grade = await _context.Grades.FindAsync(Id);
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
            var users = _userManager.Users;
            return View("~/Views/Administration/ListUsers.cshtml", users);
        }


        [HttpGet]
        [Authorize(Roles = "Administrator, Teacher, Student")]
        public async Task<IActionResult> UserFee()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User cannot be found";
                return View("~/Views/Account/Login.cshtml");
            }

            UserFeeViewModel model = await GetUserFeeViewModelFromUser(user);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Teacher, Student")]
        public async Task<IActionResult> UserFeeWithID(string userId)
        {
            ViewBag.userId = userId;

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User cannot be found";
                return View("NotFound");
            }

            UserFeeViewModel model = await GetUserFeeViewModelFromUser(user);
            return View("UserFee", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> UserFee([Bind("UserId,Title,Amount,Paid")] UserFeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Fee fee = new Fee();
                fee.Title = viewModel.Title;
                fee.Amount = viewModel.Amount;
                fee.Paid = viewModel.Paid;
                var user = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == viewModel.UserId);

                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User cannot be found";
                    return View("NotFound");
                }
                fee.User = user;
                _context.Fees.Add(fee);
                await _context.SaveChangesAsync();

                viewModel = await GetUserFeeViewModelFromUser(user);

            }
            return View(viewModel);
        }

        private async Task<UserFeeViewModel> GetUserFeeViewModelFromUser(ApplicationUser user)
        {
            UserFeeViewModel viewModel = new UserFeeViewModel();
            viewModel.User = user;
            List<Fee> fees = await _context.Fees.Where(m => m.User == user).ToListAsync();
            viewModel.Fees = fees;
            IList<string> userRoles = await _userManager.GetRolesAsync(user);
            viewModel.Roles = userRoles;
            return viewModel;

        }

        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> EditUserFee(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFee = await _context.Fees.FindAsync(id);
            if (userFee == null)
            {
                return NotFound();
            }
            return View("EditUserFee", userFee);
        }

        private bool FeeExists(string id)
        {
            return _context.Fees.Any(e => e.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> EditUserFee(string id, [Bind("Id,Title,Amount,Paid")] Fee fee)
        {
            if (id != fee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeeExists(fee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var users = _userManager.Users;
                return View("~/Views/Administration/ListUsers.cshtml", users);
            }
            return View(fee);
        }

        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> DeleteUserFee(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fee = await _context.Fees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fee == null)
            {
                return NotFound();
            }

            return View(fee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> DeleteConfirmedUserFee(string Id)
        {
            var fee = await _context.Fees.FindAsync(Id);
            _context.Fees.Remove(fee);
            await _context.SaveChangesAsync();
            var users = _userManager.Users;
            return View("~/Views/Administration/ListUsers.cshtml", users);
        }


        [HttpGet]
        [Authorize(Roles = "Administrator, Teacher, Student")]
        public async Task<IActionResult> UserClasse()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User cannot be found";
                return View("~/Views/Account/Login.cshtml");
            }

            UserClasseViewModel model = await GetUserClasseViewModelFromUser(user);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Teacher, Student")]
        public async Task<IActionResult> UserClasseWithID(string userId)
        {
            ViewBag.userId = userId;

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User cannot be found";
                return View("NotFound");
            }

            UserClasseViewModel model = await GetUserClasseViewModelFromUser(user);
            return View("UserClasse", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher, Student")]

        public async Task<IActionResult> UserClasse([Bind("UserId,Subject,Day,Hour,Attendance")] UserClasseViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Classe classe = new Classe();
                classe.Subject = viewModel.Subject;
                classe.Day = viewModel.Day;
                classe.Hour = viewModel.Hour;
                classe.Attendance = viewModel.Attendance;
                var user = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == viewModel.UserId);

                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User cannot be found";
                    return View("NotFound");
                }
                classe.User = user;
                _context.Classes.Add(classe);
                await _context.SaveChangesAsync();

                viewModel = await GetUserClasseViewModelFromUser(user);

            }
            return View(viewModel);
        }

        private async Task<UserClasseViewModel> GetUserClasseViewModelFromUser(ApplicationUser user)
        {
            UserClasseViewModel viewModel = new UserClasseViewModel();
            viewModel.User = user;
            List<Classe> classes = await _context.Classes.Where(m => m.User == user).ToListAsync();
            viewModel.Classes = classes;
            IList<string> userRoles = await _userManager.GetRolesAsync(user);
            viewModel.Roles = userRoles;
            return viewModel;

        }

        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> EditUserClasse(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userClasse = await _context.Classes.FindAsync(id);
            if (userClasse == null)
            {
                return NotFound();
            }
            return View("EditUserClasse", userClasse);
        }

        private bool ClasseExists(string id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> EditUserClasse(string id, [Bind("Id,Subject,Day,Hour,Attendance")] Classe classe)
        {
            if (id != classe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasseExists(classe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var users = _userManager.Users;
                return View("~/Views/Administration/ListUsers.cshtml", users);
            }
            return View(classe);
        }
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> DeleteUserClasse(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classe = await _context.Classes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classe == null)
            {
                return NotFound();
            }

            return View(classe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> DeleteConfirmedUserClasse(string Id)
        {
            var classe = await _context.Classes.FindAsync(Id);
            _context.Classes.Remove(classe);
            await _context.SaveChangesAsync();
            var users = _userManager.Users;
            return View("~/Views/Administration/ListUsers.cshtml", users);
        }

    }
}
