using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MiniMuhasebecim.UI.Models.Dtos.CustomerImageDtos
{
    public class CustomerImageDto
    {
        public int Id { get; set; }
        [Display(Name = "Kullanıcı no")]
        public int CustomerId { get; set; }
        [Display(Name = "Resim")]
        public string Path { get; set; }
    }
}
