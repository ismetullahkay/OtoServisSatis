using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entity;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.Service.Concrete;
using OtoServisSatis.WebUI.Models;
using OtoServisSatis.WebUI.Utils;
using System.Security.Claims;

namespace OtoServisSatis.WebUI.Controllers
{
    public class AracController : Controller
    {
        private readonly ICarService _serviceArac;
        private readonly IService<Musteri> _serviceMusteri;
        private readonly IUserService _serviceKullanici;



        public AracController(ICarService serviceArac, IService<Musteri> serviceMusteri, IUserService serviceKullanici)
        {
            _serviceArac = serviceArac;
            _serviceMusteri = serviceMusteri;
            _serviceKullanici = serviceKullanici;
        }

        public async Task<IActionResult> IndexAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var arac = await _serviceArac.GetCustomCar(id.Value);
            if (arac == null)
            {
                return NotFound();
            }
            var model = new CarDetailViewModel();
            model.Arac=arac;
            if(User.Identity.IsAuthenticated) //kullanıcı oturum acmıssa
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                var uGuid = User.FindFirst(ClaimTypes.UserData)?.Value;
                if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(uGuid))
                {
                    var user = _serviceKullanici.Get(x => x.Email == email && x.UserGuid.ToString() == uGuid);
                    if (user != null)
                    {
                        model.Musteri = new Musteri
                        {
                            Adi=user.Adi,
                            Soyadi=user.Soyadi,
                            Email=user.Email,
                            Telefon=user.Telefon,
                            
                        };
                    }
                }
            }

            return View(model);
        }
        [Route("Tum-Araclarimiz")]
        public async Task<IActionResult> CarList()
        {
            var model = await _serviceArac.GetCustomCarList(c=>c.SatistaMi);
            return View(model);
        }
        public async Task<IActionResult> Ara(string q)
        {
            var model = await _serviceArac.GetCustomCarList(c => c.SatistaMi
            && c.Marka.Adi.Contains(q) 
            || c.KasaTipis.KasaTipi.Contains(q)
            || c.Modeli.Contains(q)
            );
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> MusteriKayit(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceMusteri.AddAsync(musteri);
                    await _serviceMusteri.SaveAsync();
                    //await MailHelper.SendMailAsync(musteri);
                    TempData["Message"] = "<div class='alert alert-success'> Talebiniz Başarıyla Alınmıştır.Teşekkürler.. </div>";
                    return Redirect("/Arac/Index/" + musteri.AracId);
                }
                catch
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Talebiniz Alınırken Bir Hatayla Karşılaşıldı! Lütfen Bilgilerinizi Kontrol Ediniz </div>";
                    ModelState.AddModelError("", "Bir Hata Meydana Geldi!");
                }
            }
            return View();
        }
    }
}
