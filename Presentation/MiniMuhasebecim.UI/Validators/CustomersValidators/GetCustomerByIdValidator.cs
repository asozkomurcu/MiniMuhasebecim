using FluentValidation;
using MiniMuhasebecim.UI.Models.RequestModels.CustomerRM;

namespace MiniMuhasebecim.UI.Validators.CustomersValidators
{
    public class GetCustomerByIdValidator : AbstractValidator<GetCustomerByIdVM>
    {
        public GetCustomerByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Kullanıcı kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Kullanıcı kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
