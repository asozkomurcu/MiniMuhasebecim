using FluentValidation;
using MiniMuhasebecim.Application.Models.RequestModels.CategoryRM;

namespace MiniMuhasebecim.Application.Validators.CategoriesValidators
{
    public class GetCategoryByIdValidator : AbstractValidator<GetCategoryByIdVM>
    {
        public GetCategoryByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Kategori kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Kategori kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
