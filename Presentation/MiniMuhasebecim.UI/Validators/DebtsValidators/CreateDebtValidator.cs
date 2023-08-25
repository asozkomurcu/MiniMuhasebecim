using FluentValidation;
using MiniMuhasebecim.UI.Models.RequestModels.DebtRM;

namespace MiniMuhasebecim.UI.Validators.DebtsValidators
{
    public class CreateDebtValidator : AbstractValidator<CreateDebtVM>
    {
        public CreateDebtValidator()
        {
            RuleFor(x => x.WholesalerId)
                .NotEmpty()
                .WithMessage("Tedarikçi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Tedarikçi kimlik bilgisi sıfırdan büyük olmalıdır.");

            RuleFor(x => x.OrderDebt)
                .NotEmpty()
                .WithMessage("Sipariş tutarı boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Sipariş tutarı sıfırdan büyük olmalıdır.");
        }
    }
}
