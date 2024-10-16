using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entity;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class ServiceController : Controller
    {
        private readonly IService<Servis> _service;

        public ServiceController(IService<Servis> service)
        {
            _service = service;
        }

        // GET: ServiceController
        public async Task<ActionResult> IndexAsync()
        {
            var model =await _service.GetAllAsync();
            return View(model);
        }

        // GET: ServiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Servis servis)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(servis);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError(" ", "Bir Hata Meydana Geldi");
                }
            }
            return View(servis);
        }

        // GET: ServiceController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
           var model=await _service.FindAsync(id);
            return View(model);
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Servis servis)
        {
            try
            {
                _service.Update(servis);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(" ", "Bir Hata Meydana Geldi");
            }
            return View(servis);
        }

        // GET: ServiceController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model =await _service.FindAsync(id);
            return View(model);
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Servis servis)
        {
            try
            {
                _service.Delete(servis);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(" ", "Bir Hata Meydana Geldi");
            }
            return View();
        }
    }
}
