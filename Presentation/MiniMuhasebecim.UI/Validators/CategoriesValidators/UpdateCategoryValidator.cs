﻿using FluentValidation;
using MiniMuhasebecim.UI.Models.RequestModels.CategoryRM;

namespace MiniMuhasebecim.UI.Validators.CategoriesValidators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryVM>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Kategori kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Kategori kimlik bilgisi sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .WithMessage("Kategori adı boş olamaz.")
                .MaximumLength(100)
                .WithMessage("Kategori adı 100 karakterden fazla olamaz.");
        }
    }
}
