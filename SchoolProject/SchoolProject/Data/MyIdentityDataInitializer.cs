using Microsoft.AspNetCore.Identity;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Data
{
    public static class MyIdentityDataInitializer
    {
        public static void SeedData
    (UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers
    (UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("AllRightUser@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "AllRightUser@mail.com";
                user.Email = "AllRightUser@mail.com";

                IdentityResult result = userManager.CreateAsync
                (user, "Test_1234").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Student").Wait();
                    userManager.AddToRoleAsync(user, "Teacher").Wait();
                    userManager.AddToRoleAsync(user, "Administrator").Wait();

                }
            }
            if (userManager.FindByNameAsync("StudentUser@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "StudentUser@mail.com";
                user.Email = "StudentUser@mail.com";

                IdentityResult result = userManager.CreateAsync
                (user, "Test_1234").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Student").Wait();
                }
            }
            if (userManager.FindByNameAsync("TeacherUser@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "TeacherUser@mail.com";
                user.Email = "TeacherUser@mail.com";

                IdentityResult result = userManager.CreateAsync
                (user, "    Test_1234").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Teacher").Wait();

                }
            }
            if (userManager.FindByNameAsync("AdminUser@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "AdminUser@mail.com";
                user.Email = "AdminUser@mail.com";

                IdentityResult result = userManager.CreateAsync
                (user, "Test_1234").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();

                }
            }
        }

        public static void SeedRoles
    (RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Student").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Student";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Teacher").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Teacher";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
