using FluentValidation;
using MiniMuhasebecim.UI.Models.RequestModels.WholasalerRM;

namespace MiniMuhasebecim.UI.Validators.WholesalersValidators
{
    public class UpdateWholesalerValidator : AbstractValidator<UpdateWholesalerVM>
    {
        public UpdateWholesalerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Tedarikçi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Tedarikçi kimlik bilgisi sıfırdan büyük olmalıdır.");

            RuleFor(x => x.WholesalerName)
                .NotEmpty()
                .WithMessage("Tedarikçi adı boş olamaz.")
                .MaximumLength(50)
                .WithMessage("Tedarikçi adı 50 karakterden fazla olamaz.");
        }
    }
}
