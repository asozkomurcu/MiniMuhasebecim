using FluentValidation;
using MiniMuhasebecim.UI.Models.RequestModels.CategoryRM;

namespace MiniMuhasebecim.UI.Validators.CategoriesValidators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryVM>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .WithMessage("Kategori adı boş olamaz.")
                .MaximumLength(100)
                .WithMessage("Kategori adı 100 karakterden fazla olamaz.");
        }
    }
}
