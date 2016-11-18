using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ixy.AppService.Interface;
using Microsoft.Extensions.Logging;

namespace Ixy.Web.Controllers
{
    [RequireHttps]
    public class HomeController : IxyController
    {
        private readonly IPostService _service;
        protected readonly ILogger _logger;

        public HomeController(IPostService postService, ILoggerFactory loggerFactory)
        {
            _service = postService;
            _logger = loggerFactory.CreateLogger<HomeController>();
        }

        public async Task<IActionResult> Index()
        {

            var posts = await _service.GetAllAsync();
            return View(posts);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> BlogPost(string id)
        {
            var p = await _service.GetAsync(id);


            return View(p);
        }
    }
}
