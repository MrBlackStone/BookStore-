
using System;
using FluentValidation;

namespace WebApi.Applications.AuthorOperations.Commands.UpdateAuthor
{
    
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x=>x.AuthorId)
            .GreaterThan(0).WithMessage("Lütfen 0'dan büyük bir sayı giriniz.");
        
           RuleFor(x=>x.Model.authorName)
           .MinimumLength(4).WithMessage("Lütfen en az 4 karakter giriniz.")
           .NotEmpty().WithMessage("İsim kısmı boş bırakılamaz.");

           RuleFor(x=>x.Model.authorSurname)
           .MinimumLength(4).WithMessage("Lütfen en az 4 karakter giriniz.")
           .NotEmpty().WithMessage("Soyisim kısmı boş bırakılamaz.");

           RuleFor(x=>x.Model.birthDate)
           .NotEmpty().WithMessage("Doğum Yılı kısmı boş bırakılamaz.")
           .LessThan(DateTime.Now.Date).WithMessage("Doğum Yılı bugünden az olmalıdır.");
        }
    }
}