using Fiorello.DAL;
using Fiorello.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello.ViewComponents
{
    public class HeaderViewComponent:ViewComponent  
    {
        private AppDBContext _context { get; }
        public HeaderViewComponent(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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

            //var basket = JsonConvert
            //                .DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);

            if (basket != null)
            {
                ViewBag.BasketItemCount = basket.Count;
            }
            else
            {
                ViewBag.BasketItemCount = 0;
            }

            var setting = _context.Setting.AsEnumerable().ToDictionary(s => s.Key, s => s.Value);
            return View(await Task.FromResult(setting));
        }
    }
}
