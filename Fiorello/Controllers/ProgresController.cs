using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello.Controllers
{
    public class ProgresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
