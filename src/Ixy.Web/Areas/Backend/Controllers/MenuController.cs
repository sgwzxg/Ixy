using Ixy.Application.Service.Interface;
using Ixy.Core.Model;
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
            var menu = await _service.GetAsync(id);
            return Json(menu);
        }
    }
}