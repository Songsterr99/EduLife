using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EduLife.Data;
using EduLife.Models;
using EduLife.Models.InstructionViewModel;
using Microsoft.EntityFrameworkCore;

namespace EduLife.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_context.Instructions.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InstructionViewModel model )
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var instruction = new Instruction
                {
                    InstructionID = model.InstructionID,
                    Content = model.InstructionID,
                    CreateTime = DateTime.Now,
                    ApplicationUserID = user.Id
                };
                _context.Add(instruction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var instrustions = from inst in _context.Instructions
                               where inst.ApplicationUser == user
                               select inst;


            return View(await instrustions.AsNoTracking().ToListAsync());
        }
        //[HttpPost]
        //public async Task<IActionResult> Create(Instruction instruction)
        //{
        //    _context.Instructions.Add(instruction);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
