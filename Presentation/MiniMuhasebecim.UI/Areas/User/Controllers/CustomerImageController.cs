using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebecim.UI.Models.Dtos.CustomerImageDtos;
using MiniMuhasebecim.UI.Models.RequestModels.CustomerImageRM;
using MiniMuhasebecim.UI.Models.Wrapper;
using MiniMuhasebecim.UI.Services.Abstraction;
using System.Net;

namespace MiniMuhasebecim.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Policy = "AdminOrUser")]
    public class CustomerImageController : Controller
    {
        private readonly IRestService _restService;

        public CustomerImageController(IRestService restService)
        {
            _restService = restService;
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] int customerId)
        {
            var response = await _restService.GetAsync<Result<List<CustomerImageDto>>>($"customerImage/getAllByCustomer/{customerId}");

            if (response.StatusCode == HttpStatusCode.OK) // herşey yolunda
            {
                return View(response.Data.Data);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create([FromQuery] int customerId)
        {
            var model = new CreateCustomerImageVM
            {
                CustomerId = customerId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCustomerImageVM customerImageModel)
        {
            //Fluent validation içerisinde tanımlanan kurallardan bir veya birkaçı ihlal edildiyse
            if (!ModelState.IsValid)
            {
                return View(customerImageModel);
            }

            //Upload edilen resim dosyasını base64 string'e çevirerek istek yapacağımız modele ekleyelim.
            var ms = new MemoryStream();
            customerImageModel.ImageFile.CopyTo(ms);
            var fileAsByte = ms.ToArray();

            var fileAsBase64String = Convert.ToBase64String(fileAsByte);
            //Gelen modelde yer alan ve şu an null olan ilgili property'ye dosya içeriği
            //base64 string olarak yazılır. Bu bilgiyi api bekliyor.
            customerImageModel.UploadedImage = fileAsBase64String;

            var formData = new Dictionary<string, string>
            {
                {"CustomerId",customerImageModel.CustomerId.ToString() },
                {"UploadedImage",customerImageModel.UploadedImage }
            };

            var response = await _restService.PostFormAsync<Result<int>>(formData, "customerImage/create");

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", response.Data.Errors[0]);
                return View();
            }
            else // herşey yolunda
            {
                TempData["success"] = $"{response.Data.Data} numaralı kayıt başarıyla eklendi.";
                return RedirectToAction("List", "CustomerImage", new { Area = "User", CustomerId = customerImageModel.CustomerId });
            }

        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            //api endpointi çağır
            //productImage/delete/id

            var response = await _restService.DeleteAsync<Result<int>>($"customerImage/delete/{id}");

            return Json(response.Data);

        }

    }
}
