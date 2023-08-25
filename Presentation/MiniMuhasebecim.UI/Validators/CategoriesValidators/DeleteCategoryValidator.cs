using FluentValidation;
using MiniMuhasebecim.UI.Models.RequestModels.CategoryRM;

namespace MiniMuhasebecim.UI.Validators.CategoriesValidators
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryVM>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Kategori kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Kategori kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
