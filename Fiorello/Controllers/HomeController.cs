using Fiorello.DAL;
using Fiorello.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello.Controllers
{
    public class HomeController : Controller
    {
        private AppDBContext _db { get;  }
        public HomeController(AppDBContext db)
        {
            _db = db;
        }
        

        public async  Task<IActionResult> Index()
        {

            //HttpContext.Session.SetString("name", "Nursultan");

            HomeViewModel HomeVM = new HomeViewModel
            {
                Sliders = await _db.Sliders.ToListAsync(),
                Sliderintro = await _db.Sliderintro.FirstOrDefaultAsync(),
                Categories = await _db.Categories
                                    .Where(c => c.IsDeleted == false)
                                    .ToListAsync(),

                Products = await _db.Products
                                .Where(p => p.IsDeleted == false)
                                .Include(p => p.Category)
                                .Include(p => p.Images)
                                .OrderByDescending(p => p.Id)
                                .Take(8)
                                .ToListAsync(),

                AboutMain = await _db.AboutMain.FirstOrDefaultAsync(),
                AboutIcon = await _db.AboutIcon.ToListAsync(),

                ExspertTitle = await _db.ExspertTitle.FirstOrDefaultAsync(),
                Exsperts = await _db.Exsperts.ToListAsync(),

                BlogTitle = await _db.BlogTitle.FirstOrDefaultAsync(),
                Blogs = await _db.Blogs.ToListAsync(),

                Says = await _db.Says.ToListAsync()
                                   
                                                   

            };
            return View(HomeVM);
        }

        //public IActionResult Test()
        //{
        //    var session = HttpContext.Session.GetString("name");
        //    return Json(session);
        //}
    }
}
