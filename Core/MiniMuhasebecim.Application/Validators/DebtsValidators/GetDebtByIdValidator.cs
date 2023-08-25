using FluentValidation;
using MiniMuhasebecim.Application.Models.RequestModels.DebtRM;

namespace MiniMuhasebecim.Application.Validators.DebtsValidators
{
    public class GetDebtByIdValidator : AbstractValidator<GetDebtByIdVM>
    {
        public GetDebtByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Borç kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Borç kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
