using Microsoft.AspNetCore.Mvc;
using MiniMuhasebecim.UI.Models;
using MiniMuhasebecim.UI.Models.Dtos.AccountDtos;
using MiniMuhasebecim.UI.Models.RequestModels.AccountRM;
using MiniMuhasebecim.UI.Models.Wrapper;
using MiniMuhasebecim.UI.Services.Abstraction;
using Newtonsoft.Json;
using System.Net;

namespace MiniMuhasebecim.UI.Areas.Entry.Controllers
{
    [Area("Entry")]
    public class LoginController : Controller
    {
        private readonly IRestService _restService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public LoginController(IRestService restService, IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            _restService = restService;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signin(LoginVM loginModel, [FromQuery] string ReturnUrl)
        {

            //Model doğrulamasını geçemeyen kullanıcıyı buradan tekrar login sayfasına gönder.
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var response = await _restService.PostAsync<LoginVM, Result<TokenDto>>(loginModel, "account/login", false);

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
                else if (response.Data.Data.Role.ToString() == Roles.Admin.ToString())
                {
                    return RedirectToAction("Index", "Routing", new { Area = "Admin" });
                }
                else //(response.Data.Data.Role.ToString() == Roles.User.ToString())
                {
                    return RedirectToAction("Index", "Home", new { Area = "User" });
                }


            }

            return View(loginModel);
        }
    }
}
