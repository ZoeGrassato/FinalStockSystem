using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalSystem.Models;
using FinalSystem.Generics;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using FinalSystem.DataBinding;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
//using System.Web.Http;

namespace FinalSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Guid GetUniqueIdentifier()
        {
            var identity = (ClaimsIdentity)this.User.Identity;
            var claim = identity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(claim.Value);
            return userId;
        }

        public IActionResult ReturnLoginPage()
        {
            return Redirect("/Account/Login");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Delete()
        {
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
