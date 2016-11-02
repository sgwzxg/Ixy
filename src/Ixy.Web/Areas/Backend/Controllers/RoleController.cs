using Ixy.Core.Model.Identity;
using Ixy.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Ixy.Web.Areas.Backend.Controllers
{
    [Area("Backend")]
    [Authorize]
    public class RoleController : IxyController
    {
        private readonly RoleManager<IxyRole> _roleManager;
        protected readonly ILogger _logger;


        public RoleController(RoleManager<IxyRole> roleManager, ILoggerFactory loggerFactory)
        {
            _roleManager = roleManager;
            _logger = loggerFactory.CreateLogger<RoleController>();
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }
    }
}