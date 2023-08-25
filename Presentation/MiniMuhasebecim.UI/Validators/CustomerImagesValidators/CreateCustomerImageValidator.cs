using FluentValidation;
using MiniMuhasebecim.UI.Models.RequestModels.CustomerImageRM;

namespace MiniMuhasebecim.UI.Validators.CustomerImagesValidators
{
    public class CreateCustomerImageValidator : AbstractValidator<CreateCustomerImageVM>
    {
        public CreateCustomerImageValidator()
        {
            var allowedContentTypes = new string[] { "image/jpg", "image/jpeg", "image/png", "image/gif", "image/tiff" };
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Kullanıcı kimlik bilgisi boş olamaz.");

            RuleFor(x => x.ImageFile)
                .NotNull().WithMessage("Resim dosyası seçilmelidir.")
                .Must(x => x.Length < 1 * 1024 * 1024).WithMessage("Dosya boyutu 1 MB'dan büyük olamaz.")
                .Must(x => allowedContentTypes.Contains(x.ContentType)).WithMessage("Sadece resim dosyası seçilebilir.");
        }


    }
}
