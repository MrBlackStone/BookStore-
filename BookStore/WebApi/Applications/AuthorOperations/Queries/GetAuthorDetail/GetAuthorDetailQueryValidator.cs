
using System;
using FluentValidation;
using WebApi.Applications.AuthorOperations.DeleteAuthor;

namespace WebApi.Applications.AuthorOperations.Queries.GetAuthorDetail
{
    
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
           RuleFor(x=>x.AuthorId)
           .GreaterThan(0).WithMessage("Lütfen 0'dan büyük bir sayı giriniz.")
           .NotEmpty().WithMessage(" Numara kısmı boş bırakılamaz.");
        }
    }
}