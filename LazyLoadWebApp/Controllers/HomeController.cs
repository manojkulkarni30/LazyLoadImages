using LazyLoadWebApp.Models;
using LazyLoadWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LazyLoadWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeedService _feedService;

        public HomeController(IFeedService feedService)
        {
            _feedService = feedService;
        }

        public IActionResult Index()
        {
            var viewModel = _feedService.ReadFeed();
            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
