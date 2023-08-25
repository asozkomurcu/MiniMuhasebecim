using FluentValidation;
using MiniMuhasebecim.UI.Models.RequestModels.PaymentRM;

namespace MiniMuhasebecim.UI.Validators.PaymentsValidators
{
    public class UpdatePaymentValidator : AbstractValidator<UpdatePaymentVM>
    {
        public UpdatePaymentValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Ödeme kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Ödeme kimlik bilgisi sıfırdan büyük olmalıdır.");

            RuleFor(x => x.WholesalerId)
                .NotEmpty()
                .WithMessage("Tedarikçi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Tedarikçi kimlik bilgisi sıfırdan büyük olmalıdır.");

            RuleFor(x => x.OrderPayment)
                .NotEmpty()
                .WithMessage("Sipariş için yapılan ödeme tutarı boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Sipariş için yapılan ödeme tutarı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.PaymentType)
               .NotEmpty()
               .WithMessage("Yapılan ödeme tür bilgisi boş olamaz.")
               .IsInEnum()
               .WithMessage("Yapılan ödeme tür bilgisi geçerli değil. ( 1(Nakit) veya 2(Kredi kartı) olabilir.)");
        }
    }
}
