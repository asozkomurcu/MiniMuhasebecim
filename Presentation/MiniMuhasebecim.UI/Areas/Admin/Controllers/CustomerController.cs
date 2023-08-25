using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebecim.UI.Models.Dtos.CustomerDtos;
using MiniMuhasebecim.UI.Models.RequestModels.CustomerRM;
using MiniMuhasebecim.UI.Models.Wrapper;
using MiniMuhasebecim.UI.Services.Abstraction;
using System.Net;

namespace MiniMuhasebecim.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
    public class CustomerController : Controller
    {
        private IRestService _restService;
        private readonly IMapper _mapper;

        public CustomerController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }



        public async Task<IActionResult> List()
        {
            ViewBag.Header = "Kullanıcılar";
            ViewBag.Title = "";

            //Apiye istek at
            //customer/get
            var response = await _restService.GetAsync<Result<List<CustomerDto>>>("customer/get");

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
            ViewBag.Header = "Kullanıcı İşlemleri";
            ViewBag.Title = "Kullanıcı Rol Güncelle";

            //ilgili kategoriyi bul ve View'e git
            var response = await _restService.GetAsync<Result<CustomerDto>>($"customer/get/{id}");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                var model = _mapper.Map<UpdateCustomerVM>(response.Data.Data);
                return RedirectToAction("List", "Customer", new { Area = "Admin" });
            }

        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(UpdateCategoryVM updateCategoryModel)
        //{
        //    var response = await _restService.PutAsync<UpdateCategoryVM, Result<int>>(updateCategoryModel, $"category/update/{updateCategoryModel.Id}");

        //    if (response.StatusCode == HttpStatusCode.BadRequest)
        //    {
        //        ModelState.AddModelError("", response.Data.Errors[0]);
        //        return View();
        //    }
        //    else // herşey yolunda
        //    {
        //        TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla güncellendi.";
        //        return RedirectToAction("List", "Category", new { Area = "User" });
        //    }

        //}



        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    //api endpointi çağır
        //    //category/delete/id

        //    var response = await _restService.DeleteAsync<Result<int>>($"category/delete/{id}");

        //    return Json(response.Data);

        //}
    }
}

