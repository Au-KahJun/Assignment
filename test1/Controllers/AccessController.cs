using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using test1.Data;
using test1.Models;

namespace test1.Controllers
{
    public class AccessController : Controller
    {
        private readonly MVCdbSContext mvcDbSContext;
        public AccessController(MVCdbSContext mvcDbSContext)
        {
            this.mvcDbSContext = mvcDbSContext;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)



                return RedirectToAction("Index", "Home");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(VMLogin modelLogin)
        {

            var userCheking = mvcDbSContext.Employees.Any(x => x.Email.Equals(modelLogin.Email) && x.Password.Equals(modelLogin.Password));
            if (userCheking == true)
            {

                List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier,modelLogin.Email),new Claim("OtherProperties","Example Role")
            };


                ClaimsIdentity claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin.RememberMe
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentity), properties);

                return RedirectToAction("Index", "Employees");
            }
            ViewData["ValidateMessage"] = "User Not Found";
            return View();
        }
    }
}
