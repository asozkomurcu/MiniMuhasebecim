using FluentValidation;
using MiniMuhasebecim.UI.Models.RequestModels.PaymentRM;

namespace MiniMuhasebecim.UI.Validators.PaymentsValidators
{
    public class GetPaymentByIdValidator : AbstractValidator<GetPaymentByIdVM>
    {
        public GetPaymentByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Ödeme kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Ödeme kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
