using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Create()
        {
            var usuario = new IdentityUser()
            {
                UserName = "ffonseca"
            };

            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

            IdentityResult result = await userManager.CreateAsync(usuario, "123Tr0car@@");

            if (result.Succeeded)
                ViewBag.Resultado = "Usuario Criado com sucesso";
            else
                ViewBag.Resultado = string.Join(",", result.Errors);

            return View(); ;
        }

        public async Task<ActionResult> Login()
        {
            var appAsign = HttpContext.GetOwinContext().Get<AppSignInManager>();
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var user = await userManager.FindAsync("ffonseca", "123Tr0car@@");

            if (user != null)
                await appAsign.SignInAsync(user, true, true);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}