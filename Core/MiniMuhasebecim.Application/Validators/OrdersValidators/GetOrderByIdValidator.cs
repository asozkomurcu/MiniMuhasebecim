using FluentValidation;
using MiniMuhasebecim.Application.Models.RequestModels.OrderRM;

namespace MiniMuhasebecim.Application.Validators.OrdersValidators
{
    public class GetOrderByIdValidator : AbstractValidator<GetOrderByIdVM>
    {
        public GetOrderByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Sipariş kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Sipariş kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
