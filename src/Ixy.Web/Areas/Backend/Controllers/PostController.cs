using Ixy.Application.Service.Interface;
using Ixy.Core.Model;
using Ixy.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Web.Areas.Backend.Controllers
{
    [Authorize]
    [Area("Backend")]
    public class PostController : IxyController
    {
        private readonly IPostService _service;
        protected readonly ILogger _logger;


        public PostController(IPostService postService, ILoggerFactory loggerFactory)
        {
            _service = postService;
            _logger = loggerFactory.CreateLogger<PostController>();
        }

        public async Task<IActionResult> Index()
        {
            var posts =  await _service.GetAllAsync();
            return View(posts);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Post postEntity)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    Result = "Failed",
                    Message = GetModelStateError()
                });
            }
            postEntity.Id = Guid.NewGuid().ToString();
            postEntity.Author = "IxyAdmin";
            var result = await _service.AddAsync(postEntity);

            if (!result)
            {
                return Json(new { Result = "Failed" });
            }

            return Json(new { Result = "Success" });

        }
    }
}
