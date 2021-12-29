using Fiorello.DAL;
using Fiorello.Models;
using Fiorello.Utilities.File;
using Fiorello.ViewModel.Slider;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Fiorello.Areas.AdminFiorella.Controllers
{
    [Area("AdminFiorella")]
    public class SliderController : Controller
    {
        public int count { get; set; }
        private AppDBContext _context { get; }
        private IWebHostEnvironment _env { get; }
        public SliderController(AppDBContext context ,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_context.Sliders);
        }

        public async Task<IActionResult> Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MultipleSliderVM sliderVM)
        {
            #region Single File Upload

            //if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();

            //if (!slider.Photo.CheckFileType("image/"))
            //{
            //    ModelState.AddModelError("Photo", "File must be image type");
            //    return View();
            //}

            //if (!slider.Photo.CheckFileSize(200))
            //{
            //    ModelState.AddModelError("Photo", "File size must be less than 200kb");
            //    return View();
            //}

            //string fileName = await slider.Photo.SaveFileAsync(_env.WebRootPath, "img");

            //slider.Image = fileName;
            //await _context.Sliders.AddAsync(slider);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            #endregion

            count = 0;
            var dbcount = await _context.Sliders.ToListAsync();
            foreach (var item in dbcount)
            {
               count++;
            }

            if (ModelState["Photos"].ValidationState == ModelValidationState.Invalid) return View();

            foreach (var photo in sliderVM.Photos)
            {
                if (!photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photos", $"{photo.FileName} must be image type");
                    return View();
                }

                if (!photo.CheckFileSize(200))
                {
                    ModelState.AddModelError("Photos", $"{photo.FileName} size must be less than 200kb");
                    return View();
                }

            }

            foreach (var photo in sliderVM.Photos)
            {
                count++;
                if (count <= 5)
                {
                    string fileName = await photo.SaveFileAsync(_env.WebRootPath, "img");

                    Slider slider = new Slider
                    {
                        Image = fileName
                    };

                    await _context.Sliders.AddAsync(slider);
                }

                else
                {
                    ModelState.AddModelError("Photos", "I agede 5 den yuxari olmaz ");
                    return View();
                }
            }
            
            

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Update(int Id)
        {
            return Json(Id);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            Slider slider = await _context.Sliders.FindAsync(Id);

            if (slider == null) return NotFound();

            Helper.RemoveFile(_env.WebRootPath, "img", slider.Image);

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
