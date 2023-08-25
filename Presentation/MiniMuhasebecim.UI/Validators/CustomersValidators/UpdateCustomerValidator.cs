using FluentValidation;
using MiniMuhasebecim.UI.Models.RequestModels.CustomerRM;

namespace MiniMuhasebecim.UI.Validators.CustomersValidators
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerVM>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Güncellenecek kullanıcı kimlik numarası gönderilmelidir.");

        }
    }
}
