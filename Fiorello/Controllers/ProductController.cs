using Fiorello.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello.Controllers
{
    public class ProductController : Controller
    {
        private AppDBContext _context { get; }
        private int _productCount;
        public ProductController(AppDBContext context)
        {
            _context = context;
            _productCount = _context.Products
                                    .Where(p => p.IsDeleted == false)
                                    .Count();
        }

        public IActionResult Index()
        {
            ViewBag.productsCount = _productCount;

            return View(_context.Products
                                .Where(p => p.IsDeleted == false)
                                .Include(p => p.Images)
                                .OrderByDescending(p => p.Id)
                                .Take(8));
        }

        public IActionResult LoadProducts(int skip)
        {
            var count = _context.Settings.FirstOrDefault().Count;
            if (_productCount == skip)
            {
                return Json(new
                {
                    Info = "stopped get some help"
                });
            }
            var model = _context.Products
                                .Where(p => p.IsDeleted == false)
                                .OrderByDescending(p => p.Id)
                                .Skip(skip)
                                .Take(count)
                                .Include(p => p.Images)
                                .ToList();

            return PartialView("_ProductPartial", model);
        }


    }
}
