using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Ixy.Web.Areas.Backend.Controllers
{
    [Area("Backend")]
    [Authorize]
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}