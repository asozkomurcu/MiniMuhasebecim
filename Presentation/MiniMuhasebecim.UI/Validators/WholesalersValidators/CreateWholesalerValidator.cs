using FluentValidation;
using MiniMuhasebecim.UI.Models.RequestModels.WholasalerRM;

namespace MiniMuhasebecim.UI.Validators.WholesalersValidators
{
    public class CreateWholesalerValidator : AbstractValidator<CreateWholesalerVM>
    {
        public CreateWholesalerValidator()
        {
            RuleFor(x => x.WholesalerName)
                .NotEmpty()
                .WithMessage("Tedarikçi adı boş olamaz.")
                .MaximumLength(50)
                .WithMessage("Tedarikçi adı 50 karakterden fazla olamaz.");
        }
    }
}
