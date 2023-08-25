using Microsoft.AspNetCore.Mvc;
using MiniMuhasebecim.UI.Models.Dtos.AccountDtos;
using MiniMuhasebecim.UI.Models.RequestModels.AccountRM;
using MiniMuhasebecim.UI.Models.Wrapper;
using MiniMuhasebecim.UI.Services.Abstraction;
using Newtonsoft.Json;
using System.Net;

namespace MiniMuhasebecim.UI.Areas.Entry.Controllers
{
    [Area("Entry")]
    public class RegisterController : Controller
    {
        private readonly IRestService _restService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public RegisterController(IRestService restService, IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            _restService = restService;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(RegisterVM registerVM, [FromQuery] string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            var response = await _restService.PostAsync<RegisterVM, Result<TokenDto>>(registerVM, "account/register", true);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
            }
            else
            {
                var sessionKey = _configuration["Application:SessionKey"];
                _contextAccessor.HttpContext.Session.SetString(sessionKey, JsonConvert.SerializeObject(response.Data.Data));
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);

                }
                else
                {
                    return RedirectToAction("Index", "Home", new { Area = "User" });
                }
                

            }
            return View();
        }
    }
}
