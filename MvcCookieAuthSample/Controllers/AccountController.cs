using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;




/// <summary>
///认证授权  cookie授权
/// </summary>
namespace MvcCookieAuthSample.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// cookie认证登录
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            //传建一个Claim集合
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name,"Dream"),
                new Claim(ClaimTypes.Role,"Admin"),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return View();
        }


        /// <summary>
        /// cookie认证登录
        /// </summary>
        /// <returns></returns>
        public IActionResult MarkLogin()
        {
            //传建一个Claim集合
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name,"Dream"),
                new Claim(ClaimTypes.Role,"Admin"),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return View();
        }
        /// <summary>
        /// 注销登录
        /// </summary>
        /// <returns></returns>
        public IActionResult LoginOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }
    }
}