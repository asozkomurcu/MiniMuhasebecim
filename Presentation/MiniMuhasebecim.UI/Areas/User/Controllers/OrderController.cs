using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniMuhasebecim.UI.Models.Dtos.OrderDtos;
using MiniMuhasebecim.UI.Models.Dtos.WholasalerDtos;
using MiniMuhasebecim.UI.Models.RequestModels.OrderRM;
using MiniMuhasebecim.UI.Models.Wrapper;
using MiniMuhasebecim.UI.Services.Abstraction;
using System.Net;

namespace MiniMuhasebecim.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Policy = "AdminOrUser")]
    public class OrderController : Controller
    {
        private IRestService _restService;
        private readonly IMapper _mapper;

        public OrderController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Header = "Sipariş İşlemleri";
            ViewBag.Title = "Sipariş ekleme";
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
        public async Task<IActionResult> Create(CreateOrderVM orderModel)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(orderModel);
            }

            //Model validasyonu başarılı. Kaydı gerçekleştir.
            var response = await _restService.PostAsync<CreateOrderVM, Result<int>>(orderModel, "order/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "Order", new { Area = "User" });
            }
        }


        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Sipariş İşlemleri";
            ViewBag.Title = "Siparişleri Listeleme";

            //Apiye istek at
            //category/get
            var response = await _restService.GetAsync<Result<List<OrderDto>>>("order/get");


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


        //public async Task<IActionResult> Edit(int id)
        //{
        //    ViewBag.Header = "Gün Sonu Hesap İşlemleri";
        //    ViewBag.Title = "Gün Sonu Bilgileri Güncelleme";

        //    //ilgili kategoriyi bul ve View'e git
        //    var response = await _restService.GetAsync<Result<OrderDto>>($"order/get/{id}");

        //    if (response.StatusCode == HttpStatusCode.BadRequest)
        //    {
        //        ModelState.AddModelError("", response.Data.Errors[0]);
        //        return View();
        //    }
        //    else // herşey yolunda
        //    {
        //        var model = _mapper.Map<UpdateOrderVM>(response.Data.Data);
        //        return View(model);
        //    }

        //}

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateOrderVM updateOrderModel)
        {
            ViewBag.Header = "Sipariş İşlemleri";
            ViewBag.Title = "Sipariş Bilgileri Güncelleme";

            var response = await _restService.PutAsync<UpdateOrderVM, Result<int>>(updateOrderModel, $"order/update/{updateOrderModel.Id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
                return RedirectToAction("List", "Order", new { Area = "User" });
            }

        }

    }
}
