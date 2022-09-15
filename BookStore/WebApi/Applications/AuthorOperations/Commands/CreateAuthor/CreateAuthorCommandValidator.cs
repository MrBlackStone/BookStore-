
using System;
using FluentValidation;
using WebApi.Applications.AuthorOperations.CreateAuthor;

namespace WebApi.Applications.AuthorOperations.Commands.CreateAuthor
{
    
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
           RuleFor(x=>x.Model.authorName)
           .MinimumLength(4).WithMessage("Lütfen en az 4 karakter giriniz.")
           .NotEmpty().WithMessage("İsim kısmı boş bırakılamaz.");

           RuleFor(x=>x.Model.authorSurname)
           .MinimumLength(4).WithMessage("Lütfen en az 4 karakter giriniz.")
           .NotEmpty().WithMessage("Soyisim kısmı boş bırakılamaz.");

           RuleFor(x=>x.Model.birthDate)
           .NotEmpty().WithMessage("İsim kısmı boş bırakılamaz.")
           .LessThan(DateTime.Now.Date).WithMessage("Doğum Yılı bugünden az olmalıdır.");
        }
    }
}