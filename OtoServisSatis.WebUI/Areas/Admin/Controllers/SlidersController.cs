﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.WebUI.Utils;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class SlidersController : Controller
    {
        private readonly IService<Slider> _service;

        public SlidersController(IService<Slider> service)
        {
            _service = service;
        }

        // GET: SlidersController
        public async Task<ActionResult> IndexAsync()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: SlidersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SlidersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SlidersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Slider slider, IFormFile? Resim)
        {
            try
            {
                slider.Resim=await FileHelper.FileLoaderAsync(Resim,"/Img/Slider/");
                await _service.AddAsync(slider);
                _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Bir Hata Oluştu");
            }
            return View();
        }

        // GET: SlidersController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var data= await _service.FindAsync(id);
            return View(data);
        }

        // POST: SlidersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id,Slider slide,IFormFile? resim)
        {
            try
            {
                if (resim!=null)
                    slide.Resim = await FileHelper.FileLoaderAsync(resim, "/Img/Slider/"); 
                _service.Update(slide);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SlidersController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var data= await _service.FindAsync(id);
            return View(data);
        }

        // POST: SlidersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Slider slider)
        {
            try
            {
                _service.Delete(slider);
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
