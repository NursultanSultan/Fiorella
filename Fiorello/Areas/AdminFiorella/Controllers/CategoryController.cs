using Fiorello.DAL;
using Fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello.Areas.AdminFiorella.Controllers
{
    [Area("AdminFiorella")]
    public class CategoryController : Controller
    {
        private AppDBContext _context { get; }

        public CategoryController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid) return View();
            bool isExist = _context.Categories.Any(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());

            if (isExist)
            {
                ModelState.AddModelError("Name", "Already Exist");
                return View();
            }
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int id)
        {
            return Json(new
            {
                Action = "detail",
                Id = id
            });
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Category category)
        {
            if (!ModelState.IsValid) return View();
            bool isExist = _context.Categories.Any(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());

            if (isExist)
            {
                ModelState.AddModelError("Name", "Already Exist");
                return View();
            }
            var CategoryToUpdate = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
            CategoryToUpdate.Name = category.Name;

            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
        public IActionResult Delete(int id)
        {
            return Json(new
            {
                Action = "delete",
                Id = id
            });
        }
    }
}
