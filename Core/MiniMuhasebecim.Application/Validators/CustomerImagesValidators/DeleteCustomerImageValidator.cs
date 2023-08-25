using FluentValidation;
using MiniMuhasebecim.Application.Models.RequestModels.CustomerImageRM;

namespace MiniMuhasebecim.Application.Validators.CustomerImagesValidators
{
    public class DeleteCustomerImageValidator : AbstractValidator<DeleteCustomerImageVM>
    {
        public DeleteCustomerImageValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Silinecek kullanıcı resmine ait kimlik bilgisi boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Silinecek kullanıcı resmi kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
