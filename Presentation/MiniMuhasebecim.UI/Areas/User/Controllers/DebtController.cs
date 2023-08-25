using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniMuhasebecim.UI.Models.Dtos.DebtDtos;
using MiniMuhasebecim.UI.Models.Dtos.WholasalerDtos;
using MiniMuhasebecim.UI.Models.RequestModels.DebtRM;
using MiniMuhasebecim.UI.Models.Wrapper;
using MiniMuhasebecim.UI.Services.Abstraction;
using System.Net;

namespace MiniMuhasebecim.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Policy = "AdminOrUser")]
    public class DebtController : Controller
    {
        private IRestService _restService;
        private readonly IMapper _mapper;

        public DebtController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Header = "Açık Hesap İşlemleri";
            ViewBag.Title = "Tedarikçiye ait borç ekleme";

            var response = await _restService.GetAsync<Result<List<WholesalerDto>>>("wholesaler/get");
            //Kategori listesini açılır kutuya uygun formata dönüşüm
            ViewBag.Wholesalers = response.Data.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.WholesalerName,
            });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDebtVM createDebtVM)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(createDebtVM);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateDebtVM, Result<int>>(createDebtVM, "debt/create");
            
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "Debt", new { Area = "User" });
            }
        }


        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Açık Hesap İşlemleri";
            ViewBag.Title = "Açık Hesap Bilgileri Listeleme";

            //Apiye istek at
            //debt/get
            var response = await _restService.GetAsync<Result<List<DebtDto>>>("debt/get");

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

       

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Header = "Açık Hesap İşlemleri";
            ViewBag.Title = "Açık Hesap Bilgileri Güncelleme Listeleme";

            //ilgili borcu bul ve View'e git
            var response = await _restService.GetAsync<Result<DebtDto>>($"debt/get/{id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                var model = _mapper.Map<UpdateDebtVM>(response.Data.Data);
                return View(model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,UpdateDebtVM updateDebtModel)
        {
            var response = await _restService.PutAsync<UpdateDebtVM, Result<int>>(updateDebtModel, $"debt/update/{updateDebtModel.Id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
                return RedirectToAction("List", "Debt", new { Area = "User" });
            }

        }

    }

}
