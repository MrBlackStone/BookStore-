
using System;
using FluentValidation;
using WebApi.Applications.AuthorOperations.DeleteAuthor;

namespace WebApi.Applications.AuthorOperations.Commands.DeleteAuthor
{
    
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
           RuleFor(x=>x.AuthorId)
           .GreaterThan(0).WithMessage("Lütfen 0'dan büyük bir sayı giriniz.")
           .NotEmpty().WithMessage("Numara kısmı boş bırakılamaz.");
        }
    }
}