using Ixy.Core.Model.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Web.Areas.Backend.Controllers
{
    [Area("Backend")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<IxyUser> _userManager;
        private readonly ILogger _logger;

        public UserController(
            UserManager<IxyUser> userManager,
            ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _logger = loggerFactory.CreateLogger<UserController>();
        }

        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }
        
    }
}
