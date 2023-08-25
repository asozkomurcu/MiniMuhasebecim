using FluentValidation;
using MiniMuhasebecim.UI.Models.RequestModels.WholasalerRM;

namespace MiniMuhasebecim.UI.Validators.WholesalersValidators
{
    public class DeleteWholesalerValidator : AbstractValidator<DeleteWholesalerVM>
    {
        public DeleteWholesalerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Tedarikçi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Tedarikçi kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
