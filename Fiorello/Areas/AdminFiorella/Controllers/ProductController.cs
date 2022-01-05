using Fiorello.DAL;
using Fiorello.Models;
using Fiorello.ViewModel;
using Fiorello.ViewModel.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello.Areas.AdminFiorella.Controllers
{
    [Area("AdminFiorella")]

    public class ProductController : Controller
    {
        //public Dictionary<string,string> PageTake { get; set; }
        private AppDBContext _context { get; }
        public ProductController(AppDBContext context)
        {
            _context = context;
            //PageTake = _context.Setting.AsEnumerable().ToDictionary(s => s.Key, s => s.Value);
            
        }

         

        public async Task<IActionResult> Index(int page=1, int take=6  )
        {
            var products = await _context.Products.Where(p => p.IsDeleted == false)
                                           .OrderByDescending(p => p.Id)
                                           .Skip((page - 1)*take)
                                           .Take(take)
                                           .Include(p => p.Images)
                                           .Include(p => p.Category)
                                           .ToListAsync();

            var ProductVMs = GetProductList(products);
            var PageCount = getPageCount(take);
            Paginate<ProductListVM> model = new Paginate<ProductListVM>(ProductVMs, page, PageCount);

            return View(model);
        }
        private int getPageCount(int take)
        {
            var pageCount = _context.Products.Where(p => p.IsDeleted == false).Count();
            return (int)Math.Ceiling((decimal)pageCount / take);
        }

        private List<ProductListVM> GetProductList(List<Product> products)
        {
            List<ProductListVM> model = new List<ProductListVM>();
            foreach (var item in products)
            {
                var product = new ProductListVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Conut = item.Conut,
                    Photo = item.Images.Where(i => i.IsMain == true).FirstOrDefault().Image,
                    CategoryName = item.Category.Name

                };
                model.Add(product);
            }
            return model;
        }

        public IActionResult Create()
        {
            ViewBag.Category = _context.Categories.ToList();
            return View();
        } 

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Product product)
        //{
        //    if (!ModelState.IsValid) return View();
        //    bool IsExist = _context.Products.Any(p => p.Name.ToLower().Trim() == product.Name.ToLower().Trim());
        //    if (IsExist)
        //    {
        //        ModelState.AddModelError("Name", "the Name is already exist");
        //        return View();
        //    }

        //    await _context.Products.AddAsync(product);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));

        //}


    }
}
