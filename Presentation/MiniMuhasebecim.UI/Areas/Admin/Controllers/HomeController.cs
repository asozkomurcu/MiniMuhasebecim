using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MiniMuhasebecim.UI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        [Authorize(Policy = "Admin")]
        public IActionResult Index()
        {
            ViewBag.Header = "Mini Muhasebe";
            ViewBag.Title = "Yönetim Paneli";
            return View();
        }
    }
}
