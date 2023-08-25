using FluentValidation;
using MiniMuhasebecim.UI.Models.RequestModels.CustomerImageRM;

namespace MiniMuhasebecim.UI.Validators.CustomerImagesValidators
{
    public class GetAllCustomerImageByCustomerValidator : AbstractValidator<GetAllCustomerImageByCustomerVM>
    {
        public GetAllCustomerImageByCustomerValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotNull().WithMessage("Kullanıcıya ait kimlik bilgisi boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Kullanıcıya ait kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
