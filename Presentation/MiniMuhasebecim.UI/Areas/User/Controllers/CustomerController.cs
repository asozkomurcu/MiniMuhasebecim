using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebecim.UI.Models.Dtos.CustomerDtos;
using MiniMuhasebecim.UI.Models.Wrapper;
using MiniMuhasebecim.UI.Services.Abstraction;
using System.Net;

namespace MiniMuhasebecim.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Policy = "AdminOrUser")]
    public class CustomerController : Controller
    {
        private IRestService _restService;
        private readonly IMapper _mapper;

        public CustomerController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }

        public IActionResult CustomerHome() 
        {
            ViewBag.Header = "Kullanıcı Bilgilerim";
            ViewBag.Title = "";
            return View();
        }

        public async Task<IActionResult> List(int id)
        {
            ViewBag.Header = "Kullanıcı Bilgilerim";
            ViewBag.Title = "";

            //Apiye istek at
            //customer/get
            
            var response = await _restService.GetAsync<Result<List<CustomerDto>>>($"customer/get/{id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "İşlem esnasında sunucu taraflı bir hata oluştu. Lütfen sistem yöneticinize başvurunuz.");
                return View();
            }
            else
            {
                return View(response.Data.Data);
            }
        }
       

       
    }
}
