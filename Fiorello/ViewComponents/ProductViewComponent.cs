using Fiorello.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello.ViewComponents
{
    public class ProductViewComponent:ViewComponent
    {
        private AppDBContext _context;

        public ProductViewComponent(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _context.Products
                                .Where(p => p.IsDeleted == false)
                                .Include(p => p.Images)
                                .Include(p => p.Category)
                                .OrderByDescending(p => p.Id)
                                .Skip(8)
                                .Take(8)
                                .ToListAsync();
            return View(await Task.FromResult(model));
        }
    }
}
