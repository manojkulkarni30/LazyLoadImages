using LazyLoadWebApp.Models;
using LazyLoadWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LazyLoadWebApp.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        private readonly IFeedService _feedService;

        #endregion

        #region Ctor

        public HomeController(IFeedService feedService)
        {
            _feedService = feedService;
        }

        #endregion

        #region Methods

        public async Task<IActionResult> Index()
        {
            var viewModel = await _feedService.ReadFeedAsync();
            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

        #endregion
    }
}
