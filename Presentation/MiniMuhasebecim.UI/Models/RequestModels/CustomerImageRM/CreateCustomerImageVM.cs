using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MiniMuhasebecim.UI.Models.RequestModels.CustomerImageRM
{
    public class CreateCustomerImageVM
    {
        public int CustomerId { get; set; }
        [Display(Name = "Resim Dosyası")]
        public IFormFile ImageFile { get; set; }
        public string UploadedImage { get; set; }
    }
}
