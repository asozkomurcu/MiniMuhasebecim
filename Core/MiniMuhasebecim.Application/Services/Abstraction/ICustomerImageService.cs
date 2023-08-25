using MiniMuhasebecim.Application.Models.Dtos.CustomerImageDtos;
using MiniMuhasebecim.Application.Models.RequestModels.CustomerImageRM;
using MiniMuhasebecim.Application.Wrapper;

namespace MiniMuhasebecim.Application.Services.Abstraction
{
    public interface ICustomerImageService
    {
        #region Select

        Task<Result<List<CustomerImageDto>>> GetAllImagesByCustomer(GetAllCustomerImageByCustomerVM getByCustomerVM);
        Task<Result<List<CustomerImageWithCustomerDto>>> GetAllCustomerImagesWithCustomer(GetAllCustomerImageByCustomerVM getByCustomerVM);

        #endregion

        #region Insert, Update, Delete

        Task<Result<int>> CreateCustomerImage(CreateCustomerImageVM createCustomerImageVM);
        Task<Result<int>> DeleteCustomerImage(DeleteCustomerImageVM deleteCustomerImageVM);

        #endregion
    }
}
