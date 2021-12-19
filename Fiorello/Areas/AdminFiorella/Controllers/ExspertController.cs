using Fiorello.DAL;
using Microsoft.AspNetCore.Mvc;


namespace Fiorello.Areas.AdminFiorella.Controllers
{
    [Area("AdminFiorella")]

    public class ExspertController : Controller
    {
        private AppDBContext _context { get; }
        public ExspertController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Exsperts);
        }
    }
}
