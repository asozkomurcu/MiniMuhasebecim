using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MiniMuhasebecim.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
    public class RoutingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
