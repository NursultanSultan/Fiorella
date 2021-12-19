using Fiorello.DAL;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Detail(int id)
        {
            return Json(new
            {
                Action = "detail",
                Id = id
            });
        }

        public IActionResult Update(int id)
        {
            return Json(new
            {
                Action = "update",
                Id = id
            });
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
