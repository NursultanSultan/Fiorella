using Microsoft.AspNetCore.Mvc;


namespace Fiorello.Areas.AdminFiorella.Controllers
{
    [Area("AdminFiorella")]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
