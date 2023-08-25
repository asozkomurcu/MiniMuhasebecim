using FluentValidation;
using MiniMuhasebecim.Application.Models.RequestModels.CustomerRM;

namespace MiniMuhasebecim.Application.Validators.CustomersValidators
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
