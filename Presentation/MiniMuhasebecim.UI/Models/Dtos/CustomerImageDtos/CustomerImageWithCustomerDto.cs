using MiniMuhasebecim.UI.Models.Dtos.CustomerDtos;

namespace MiniMuhasebecim.UI.Models.Dtos.CustomerImageDtos
{
    public class CustomerImageWithCustomerDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Path { get; set; }

        public CustomerDto Customer { get; set; }
    }
}
