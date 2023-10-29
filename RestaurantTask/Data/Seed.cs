
using Microsoft.AspNetCore.Identity;
using RestaurantTask.Models;
using System.ComponentModel.DataAnnotations;

namespace RestaurantTask.Data
{
    public class Seed 
    {
       

        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            List<AppUser> users = new List<AppUser>
            {
                new()
                {
                    Email = "karim@gmail.com",
                    UserName = "Karim"
                },
                new()
                {
                    Email = "Yanal@gmail.com",
                    UserName = "Yanal"
                },
                new()
                {
                    Email = "Ihab@gmail.com",
                    UserName = "Ihab"
                }
            };


            List<IdentityRole> roles = new List<IdentityRole>
            {
                new()
                {
                    Name = "Admin",
                },
                new()
                {
                    Name = "User",
                }
            };

            
            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "String1@");
                await userManager.AddToRoleAsync(user, "User");
            }

            AppUser admin = new AppUser
            {

                Email = "admin@gmail.com",
                UserName = "Admin"
            };
            await userManager.CreateAsync(admin, "Admin1@");
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}
