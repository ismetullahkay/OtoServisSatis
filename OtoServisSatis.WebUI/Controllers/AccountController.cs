﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entity;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.WebUI.Models;
using System.Security.Claims;

namespace OtoServisSatis.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _service;
        private readonly IService<Rol> _serviceRol;

        public AccountController(IUserService service, IService<Rol> serviceRol)
        {
            _service = service;
            _serviceRol = serviceRol;
        }
        [Authorize(Policy = "CustomerPolicy")]
        public IActionResult Index()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var uGuid = User.FindFirst(ClaimTypes.UserData)?.Value;
            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(uGuid))
            {
                var user = _service.Get(x => x.Email == email && x.UserGuid.ToString() == uGuid);
                if (user != null)
                {
                    return View(user);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult UserUpdate(Kullanici kullanici)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                var uGuid = User.FindFirst(ClaimTypes.UserData)?.Value;
                if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(uGuid))
                {
                    var user = _service.Get(x => x.Email == email && x.UserGuid.ToString() == uGuid);
                    if (user != null)
                    {
                        user.Adi = kullanici.Adi;
                        user.Email = kullanici.Email;
                        user.AktifMi = kullanici.AktifMi;
                        user.UserGuid = kullanici.UserGuid;
                        user.Sifre = kullanici.Sifre;
                        user.EklenmeTarihi = kullanici.EklenmeTarihi;
                        user.Soyadi = kullanici.Soyadi;
                        user.Telefon = kullanici.Telefon;

                        _service.Update(user);
                        _service.Save();
                        return Redirect("/Home");
                    }
                }

            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Bir Hata Meydana Geldi!");
            }

            return RedirectToAction("Index");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var rol = await _serviceRol.GetAsync(r => r.Adi == "Customer");

                    if (rol == null)
                    {
                        ModelState.AddModelError("", "Kayıt Olurken Bir Sorunla Karşılaşıldı! ");
                        return View();
                    }
                    kullanici.RolId = rol.Id;
                    kullanici.AktifMi = true;
                    await _service.AddAsync(kullanici);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu! ");
                }

            }

            return View();
        }
        public async Task<IActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Home");
        }
        public IActionResult Login(Kullanici kullanici)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(CustomerLoginViewModel customerViewModel)
        {
            try
            {
                var account = await _service.GetAsync(k => k.Email == customerViewModel.Email && k.Sifre == customerViewModel.Sifre && k.AktifMi == true);
                if (account == null)
                {
                    ModelState.AddModelError("", "Giriş Yapılırken Bir Sorunla Karşılaşıldı! ");
                }
                else
                {
                    var rol = _serviceRol.Get(r => r.Id == account.RolId);
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name ,account.Adi),
                        new Claim(ClaimTypes.Email ,account.Email),
                        new Claim(ClaimTypes.UserData ,account.UserGuid.ToString())

                    };
                    if (rol != null)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, rol.Adi));
                    }

                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    if (rol.Adi == "Admin")
                    {
                        return Redirect("/Admin");
                    }
                    return Redirect("/Home");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Bir Sorunla Karşılaşıldı! ");
            }
            return View();
        }

    }
}
