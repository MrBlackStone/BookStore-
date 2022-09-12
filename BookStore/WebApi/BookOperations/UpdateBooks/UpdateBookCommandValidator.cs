
using FluentValidation;

namespace WebApi.BookOperations.UpdateBooks
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x=>x.BookId)
            .GreaterThan(0).WithMessage("Lütfen 0'dan büyük bir sayı giriniz.");
            
            RuleFor(x=> x.Model.Title)
            .MinimumLength(4).WithMessage("Lütfen en az 4 karakter kullanınız")
            .NotEmpty().WithMessage("Lütfen boş bırakmayınız.");

            RuleFor(x=> x.Model.Genre)
            .GreaterThan(0).WithMessage("Lütfen 0'dan büyük bir sayı giriniz.")
            .NotEmpty().WithMessage("Lütfen boş bırakmayınız.");
        }
    }
}