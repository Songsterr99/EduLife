using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using EduLife.Models;
using EduLife.Data;

namespace EduLife
{
    public class DbInitialize
    {
        public static async Task InitializeAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string dimaEmail = "dima@gmail.com";
            string dimaPassword = "Dima123!";
            string philEmail = "phil@gmail.com";
            string philPassword = "Phil123!";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await userManager.FindByNameAsync(dimaEmail) == null)
            {
                ApplicationUser admin = new ApplicationUser { Email = dimaEmail, UserName = dimaEmail };
                IdentityResult result = await userManager.CreateAsync(admin, dimaPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
                Instruction instruction = new Instruction { InstructionID = "Work", Content = "I will tell", CreateTime = DateTime.Parse("2017-02-02"), ApplicationUserID = admin.Id };
                Instruction instruction2 = new Instruction { InstructionID = "Worker", Content = "I will tell you", CreateTime = DateTime.Parse("2017-02-02"), ApplicationUserID = admin.Id };
                context.Instructions.Add(instruction);
                context.Instructions.Add(instruction2);
                context.SaveChanges();


            }
            if (await userManager.FindByNameAsync(philEmail) == null)
            {
                ApplicationUser admin = new ApplicationUser { Email = philEmail, UserName = philEmail };
                IdentityResult result = await userManager.CreateAsync(admin, philPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
                Instruction instruction = new Instruction { InstructionID = "Work", Content = "I will tell", CreateTime = DateTime.Parse("2017-02-02"), ApplicationUserID = admin.Id };
                Instruction instruction2 = new Instruction { InstructionID = "Worker", Content = "I will tell", CreateTime = DateTime.Parse("2017-02-02"), ApplicationUserID = admin.Id };
                Instruction instruction3 = new Instruction { InstructionID = "Song", Content = "I will tell", CreateTime = DateTime.Parse("2017-02-02"), ApplicationUserID = admin.Id };
                context.Instructions.Add(instruction);
                context.Instructions.Add(instruction2);
                context.Instructions.Add(instruction3);
                context.SaveChanges();
            }






        }

    }
}
