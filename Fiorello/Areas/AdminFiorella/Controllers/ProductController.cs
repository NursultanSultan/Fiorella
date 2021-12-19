using Fiorello.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello.Areas.AdminFiorella.Controllers
{
    [Area("AdminFiorella")]

    public class ProductController : Controller
    {
        private AppDBContext _context { get; }
        public ProductController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Products);
        }
    }
}
