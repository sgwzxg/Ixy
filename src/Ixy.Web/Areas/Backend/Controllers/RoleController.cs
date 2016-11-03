using Ixy.Core.Model.Identity;
using Ixy.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Get(int startPage, int pageSize)
        {
            var role = await _roleManager.Roles.Skip((startPage - 1) * pageSize).Take(pageSize).ToListAsync();
            var rowCount = role.Count();
            return Json(
                new
                {
                    rowCount = role.Count(),
                    pageCount = Math.Ceiling(Convert.ToDecimal(rowCount) / pageSize),
                    rows = role
                }
                );
        }

        public async Task<IActionResult> Get(string id)
        {
            var role = await _roleManager.Roles.Where(t => t.Id == id).ToListAsync();
            var rowCount = role.Count();
            return Json(
                new
                {
                    rowCount = role.Count(),
                    pageCount = 0,
                    rows = role
                }
                );
        }


    }
}