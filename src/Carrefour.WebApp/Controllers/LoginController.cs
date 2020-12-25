using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Carrefour.Web.Framework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Carrefour.WebApp.Controllers
{
    public class LoginController : Controller
    {
        [SkipUserAuthorizeAttribute]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [SkipUserAuthorize]
        public async Task<IActionResult> Login(string userName, string userPassWord)
        {
            if (userName == "admin" && userPassWord == "admin")
            {
                var identity = new ClaimsPrincipal(
                    new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Sid,"009"),
                        new Claim(ClaimTypes.Role,"超级管理员"),
                        new Claim(ClaimTypes.Name,userName)
                    }, CookieAuthenticationDefaults.AuthenticationScheme)
                );
                await HttpContext.SignInAsync(MyAuthorization.UserAuthenticationScheme, identity, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(60),
                    IsPersistent = true,
                    AllowRefresh = false
                });
                
            }
            return   RedirectToAction("Index", "Home");
        }
        [SkipUserAuthorize]
        public async Task<RedirectResult> Logout(string returnurl)
        {
            await HttpContext.SignOutAsync(MyAuthorization.UserAuthenticationScheme);
            return Redirect(returnurl ?? "~/");
        }
    }
}
