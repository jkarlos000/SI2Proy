using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SI2Proy.Areas.Identity.Pages.Account;
using SI2Proy.Models;

namespace SI2Proy.Controllers
{
    public class HomeController : Controller
    {
        //propiedad
        public static string IdUserLoggin { get; set; }

        public IActionResult Index()
        {
            // var userID = await _userManager.FindByIdAsync(User.Identity.Name);

            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("~/Identity/Account/Login");
            }

            if (User.Identity.IsAuthenticated)
                IdUserLoggin = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
