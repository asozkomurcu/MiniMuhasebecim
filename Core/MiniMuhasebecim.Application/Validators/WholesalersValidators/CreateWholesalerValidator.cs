using FluentValidation;
using MiniMuhasebecim.Application.Models.RequestModels.WholasalerRM;

namespace MiniMuhasebecim.Application.Validators.WholesalersValidators
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
