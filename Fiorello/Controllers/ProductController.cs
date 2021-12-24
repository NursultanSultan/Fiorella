using Fiorello.DAL;
using Fiorello.Models;
using Fiorello.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        //public IActionResult LoadProducts(int skip)
        //{
        //    var count = _context.Setting.Value;
        //    if (_productCount == skip)
        //    {
        //        return Json(new
        //        {
        //            Info = "stopped get some help"
        //        });
        //    }
        //    //var model = _context.Products
        //    //                    .Where(p => p.IsDeleted == false)
        //    //                    .OrderByDescending(p => p.Id)
        //    //                    .Skip(skip)
        //    //                    .Take(count)
        //    //                    .Include(p => p.Images)
        //    //                    .ToList();

        //    return ViewComponent("Product") ;
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return BadRequest();

            List<BasketVM> basket = GetBasket();
            UpdateBasket((int)id, basket);


            return RedirectToAction("Index", "Home");
        }

        private void UpdateBasket(int id , List<BasketVM> basket)
        {
            BasketVM basketProduct = basket.Find(p => p.Id == id);
            if (basketProduct == null)
            {
                basket.Add(new BasketVM
                {
                    Id = id ,
                    Count = 1
                }); 
            }
            else
            {
                basketProduct.Count += 1;
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
        }

        private List<BasketVM> GetBasket()
        {
            List<BasketVM> basket;
            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert
                        .DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketVM>();
            }

            return basket;
        }

        public async Task<IActionResult> Basket()
        {
            List<BasketVM> basket = GetBasket();
            List<BasketItemVM> model = await GetBasketList(basket);
            return View(model);
        }

        private async Task<List<BasketItemVM>> GetBasketList(List<BasketVM> basket)
        {
            List<BasketItemVM> model = new List<BasketItemVM>();
            foreach (var item in basket)
            {
                Product dbproduct = await _context.Products
                                            .Include(p => p.Images)
                                            .FirstOrDefaultAsync(p => p.Id == item.Id);
                BasketItemVM itemVM =await GetBasketItem(item, dbproduct);
                model.Add(itemVM);
            }
            return model;
        }

        private async Task<BasketItemVM> GetBasketItem(BasketVM item ,Product dbproduct)
        {
            return new BasketItemVM
            {
                Id = item.Id,
                Name = dbproduct.Name,
                Count = item.Count,
                StockCount = dbproduct.Conut,
                Image = dbproduct.Images.Where(i => i.IsMain).FirstOrDefault().Image,
                Price = dbproduct.Price,


            };
        }
    }
}
