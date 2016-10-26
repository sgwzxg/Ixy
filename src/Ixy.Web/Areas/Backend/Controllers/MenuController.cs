using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ixy.Applications.Services;
using Ixy.Data.Models;

namespace Ixy.Web.Areas.Backend.Controllers
{
    [Area("Backend")]
    [Authorize]
    public class MenuController : Controller
    {
        private readonly IMenuService _service;

        public MenuController(IMenuService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuTreeData()
        {
            var menus = await _service.GetAllAsync();

            List<TreeNode> treeModels = new List<TreeNode>();
            foreach (var menu in menus)
            {
                treeModels.Add(new TreeNode() { Id = menu.Id.ToString(), Name = menu.Name, ParentId = menu.ParentId == Guid.Empty.ToString() ? "#" : menu.ParentId });
            }
            return Json(treeModels);
        }

        public async Task<IActionResult> GetByParent(string parentId, int startPageIndex, int pageSize)
        {
            var menu = await _service.GetByParentAsync(parentId, startPageIndex, pageSize);
            var rowCount = menu.Count();
            return Json(
                new
                {
                    rowCount = menu.Count(),
                    pageCount = Math.Ceiling(Convert.ToDecimal(rowCount) / pageSize),
                    rows = menu
                }
                );
        }

        public async Task<IActionResult> Get(string id)
        {
            var menu =await _service.GetAsync(id);
            return Json(menu);
        }
    }
}