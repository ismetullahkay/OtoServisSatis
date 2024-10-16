using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Entity;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.WebUI.Utils;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class CarsController : Controller
    {
        private readonly IService<Arac> _service;
        private readonly IService<Marka> _serviceMarka;
        private readonly IService<KasaTipis> _serviceKasa;
        //if you are not called in Constructor you have to do error message so dont forget called in constructor

        public CarsController(IService<Arac> service, IService<Marka> serviceMarka, IService<KasaTipis> serviceKasa)
        {
            _service = service;
            _serviceMarka = serviceMarka;
            _serviceKasa = serviceKasa;
        }

        // GET: CarsController
        public async Task<IActionResult> IndexAsync()
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            

            var model =await _service.GetAllAsync();

            return View(model);
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarsController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.KasaTipisId = new SelectList(await _serviceKasa.GetAllAsync(), "Id", "KasaTipi");
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
          
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Arac arac,IFormFile? Resim1,IFormFile? Resim2,IFormFile? Resim3)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    arac.Resim1=await FileHelper.FileLoaderAsync(Resim1, filePath: "/Img/Cars/");
                    arac.Resim2=await FileHelper.FileLoaderAsync(Resim2, filePath: "/Img/Cars/");
                    arac.Resim3=await FileHelper.FileLoaderAsync(Resim3,"/Img/Cars/");

                    await _service.AddAsync(arac);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Bir Hata Meydana Geldi ! ");
                }
                
            }
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            ViewBag.KasaTipisId = new SelectList(await _serviceKasa.GetAllAsync(), "Id", "KasaTipi");
            
            
            return View(arac);
        }

        // GET: CarsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            ViewBag.KasaTipiId = new SelectList(await _serviceKasa.GetAllAsync(), "Id", "KasaTipi");
            var model =await _service.FindAsync(id);
            return View(model);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Arac arac, IFormFile? Resim1, IFormFile? Resim2, IFormFile? Resim3)
        {
            try
            {
                if (Resim1 !=null)
                {
                    arac.Resim1 = await FileHelper.FileLoaderAsync(Resim1,filePath: "/Img/Cars/");
                }
                if (Resim2 != null)
                {
                    arac.Resim2 = await FileHelper.FileLoaderAsync(Resim1,"/Img/Cars/");
                }
                if (Resim3 != null)
                {
                    arac.Resim3 = await FileHelper.FileLoaderAsync(Resim1, filePath: "/Img/Cars/");
                }
                 _service.Update(arac);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu! ");
            }
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            ViewBag.KasaTipiId = new SelectList(await _serviceKasa.GetAllAsync(), "Id", "KasaTipi");

            return View(arac);

        }

        // GET: CarsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model= await _service.FindAsync(id);
            return View(model);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Arac arac)
        {
            try
            {
                 _service.Delete(arac);
               await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
