using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MiniMuhasebecim.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Policy ="AdminOrUser")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
