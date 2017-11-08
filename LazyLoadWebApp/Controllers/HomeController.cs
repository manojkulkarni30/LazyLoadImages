using LazyLoadWebApp.Models;
using LazyLoadWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LazyLoadWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeedService _feedService;

        public HomeController(IFeedService feedService)
        {
            _feedService = feedService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _feedService.ReadFeedAsync();
            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
