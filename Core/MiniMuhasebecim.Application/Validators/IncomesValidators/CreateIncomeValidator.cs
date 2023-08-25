using FluentValidation;
using MiniMuhasebecim.Application.Models.RequestModels.IncomeRM;

namespace MiniMuhasebecim.Application.Validators.IncomesValidators
{
    public class CreateIncomeValidator : AbstractValidator<CreateIncomeVM>
    {
        public CreateIncomeValidator()
        {
            RuleFor(x => x.Cash)
                .NotNull().WithMessage("Nakit para alanı boş olamaz.")
                .GreaterThan(-1).WithMessage("Nakit para alanı sıfır veya daha büyük bir değer olmalı.");

            RuleFor(x => x.CreditCard1)
                .NotNull().WithMessage("Kredi Kartı alanı boş olamaz.")
                .GreaterThan(-1).WithMessage("Kredi Kartı alanı sıfır veya daha büyük bir değer olmalı.");

            RuleFor(x => x.CreditCard2)
                .NotNull().WithMessage("Kredi Kartı alanı boş olamaz.")
                .GreaterThan(-1).WithMessage("Kredi Kartı alanı sıfır veya daha büyük bir değer olmalı.");
        }
    }
}
