using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.Abstract;
using StoreApp.WEBUI.EmailServices;
using StoreApp.WEBUI.Extensions;
using StoreApp.WEBUI.Identity;
using StoreApp.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IEmailService _emailService;
        private ICartService _cartService;
        private IFavoriteService _favoriteService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailService emailService, ICartService cartService, IFavoriteService favoriteService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
            _cartService = cartService;
            _favoriteService = favoriteService;
        }

        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                //email doğrulama tokenla
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = code
                });

                await _emailService.SendEmailAsync(model.Email, "Store App Hesap Onayı", $"Lütfen email hesabınızı onaylamak için linke <a href='http://localhost:63024{callbackUrl}'>tıklayınız.</a>");

                TempData.Put("message", new ResultMessage()
                {
                    Title="Hesap Onayı",
                    Message="E-posta adresinize gelen link ile hesabınızı onaylayınız.",
                    Css="warning"
                });

                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "Bilinmeyen hata oluştu lütfen tekrar deneyiniz. Hatırlatma: Parolanız 6 karakterden fazla olmalı bir büyük bir küçük harf ve bir sembol içermelidir.");
            return View(model);
        }


        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Bu email ile daha önce hesap oluşturulmamış.");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Lütfen hesabınızı email ile onaylayınız.");
                return View(model);
            }


            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true/* => kullanıcının hesabı kayıtlı kalsınmı*/, false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "~/");
            }

            ModelState.AddModelError("", "Email veya parola yanlış!");

            return View();

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }


        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Hesap Onayı",
                    Message = "Hesap onayı için bilgileriniz yanlış.",
                    Css = "danger"
                });
                return Redirect("~/");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    //create cart and favorite
                    _cartService.InitializeCart(user.Id);
                    _favoriteService.InitializeFavorite(user.Id);


                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Hesap Onayı",
                        Message = "Hesabınız başarıyla onaylanmıştır.",
                        Css = "success"
                    });
                    return RedirectToAction("Login");
                }


            }


            TempData.Put("message", new ResultMessage()
            {
                Title = "Hesap Onayı",
                Message = "Hesabınız onaylanamadı.",
                Css = "danger"
            });
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Şifremi Unuttum",
                    Message = "Bilgileriniz Hatalı",
                    Css = "danger"
                });

                return View();
            }

            var user = await _userManager.FindByEmailAsync(Email);

            if (user==null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Şifremi Unuttum",
                    Message = "E-posta adresi ile bir kullanıcı bulunamadı.",
                    Css = "danger"
                });
                return View();
            }

            var _token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = Url.Action("ResetPassword", "Account", new
            {
                token = _token
            });

            await _emailService.SendEmailAsync(Email, "Store App Parola Sıfırlama", $"Lütfen parolanızı yenilemek için linke <a href='http://localhost:63024{callbackUrl}'>tıklayınız.</a>");
            
            TempData.Put("message", new ResultMessage()
            {
                Title = "Şifremi Unuttum",
                Message = "Parola yenilemek için hesabınıza mail gönderildi.",
                Css = "warning  "
            });

            return RedirectToAction("Login", "Account");
        }

        public IActionResult ResetPassword(string token)
        {
            if (token==null)
            {
                return RedirectToAction("Home", "Index");
            }
            var model = new ResetPasswordModel { Token = token };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user==null)
            {
                return RedirectToAction("Home", "Index");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
