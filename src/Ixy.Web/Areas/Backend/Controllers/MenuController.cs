using Ixy.AppService.Interface;
using Ixy.Core;
using Ixy.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Web.Areas.Backend.Controllers
{
    [Area("Backend")]
    [Authorize]
    public class MenuController : IxyController
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

        public async Task<IActionResult> Edit(MenuItem menuItem)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    Result = "Failed",
                    Message = GetModelStateError()
                });
            }

            var result = await _service.EditAsync(menuItem);

            if (!result)
            {
                return Json(new { Result = "Success" });
            }

            return Json(new { Result = "Failed" });

        }

        [HttpGet]
        public async Task<IActionResult> GetMenuTreeData()
        {
            var menus = await _service.GetAsync();

            List<TreeNode> treeModels = new List<TreeNode>();
            foreach (var menu in menus)
            {
                treeModels.Add(new TreeNode() { Id = menu.Id.ToString(), Text = menu.Name, Parent = menu.ParentId == Guid.Empty.ToString() ? "#" : menu.ParentId });
            }
            return Json(treeModels);
        }

        public async Task<IActionResult> GetByParent(string parentId, int startPageIndex, int pageSize)
        {
            var menu = await _service.GetAsync(t => t.ParentId == parentId, startPageIndex, pageSize);
            var rowCount = menu.Item2;
            return Json(
                new
                {
                    rowCount = rowCount,
                    pageCount = Math.Ceiling(Convert.ToDecimal(rowCount) / pageSize),
                    rows = menu
                }
                );
        }

        public async Task<IActionResult> Get(string id)
        {
            var menu = await _service.GetByIdAsync(id);
            return Json(menu);
        }
    }
}