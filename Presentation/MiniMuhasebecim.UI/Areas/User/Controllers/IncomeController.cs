using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebecim.UI.Models.Dtos.IncomeDtos;
using MiniMuhasebecim.UI.Models.RequestModels.IncomeRM;
using MiniMuhasebecim.UI.Models.Wrapper;
using MiniMuhasebecim.UI.Services.Abstraction;
using System.Net;

namespace MiniMuhasebecim.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Policy = "AdminOrUser")]
    public class IncomeController : Controller
    {
        private IRestService _restService;
        private readonly IMapper _mapper;

        public IncomeController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            ViewBag.Header = "Gün Sonu Hesap İşlemleri";
            ViewBag.Title = "Günlük Kazanç ekleme";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIncomeVM incomeModel)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(incomeModel);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateIncomeVM, Result<int>>(incomeModel, "income/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "Income", new { Area = "User" });
            }
        }


        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Gün Sonu Hesap İşlemleri";
            ViewBag.Title = "Gün Sonu Bilgileri Listeleme";

            //Apiye istek at
            //category/get
            var response = await _restService.GetAsync<Result<List<IncomeDto>>>("income/get");


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
            ViewBag.Header = "Gün Sonu Hesap İşlemleri";
            ViewBag.Title = "Gün Sonu Bilgileri Güncelleme";

            //ilgili kategoriyi bul ve View'e git
            var response = await _restService.GetAsync<Result<IncomeDto>>($"income/get/{id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                var model = _mapper.Map<UpdateIncomeVM>(response.Data.Data);
                return View(model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateIncomeVM updateIncomeModel)
        {
            var response = await _restService.PutAsync<UpdateIncomeVM, Result<int>>(updateIncomeModel, $"income/update/{updateIncomeModel.Id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
                return RedirectToAction("List", "Income", new { Area = "User" });
            }

        }

    }
}
