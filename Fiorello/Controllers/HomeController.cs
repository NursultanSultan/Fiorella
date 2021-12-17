using Fiorello.DAL;
using Fiorello.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var slider = await _db.Sliders.ToListAsync();

            HomeViewModel HomeVM = new HomeViewModel
            {
                Sliders = await _db.Sliders.ToListAsync(),
                Sliderintro = await _db.Sliderintro.FirstOrDefaultAsync()

            };
            return View(HomeVM);
        }
    }
}
