
using System;
using FluentValidation;

namespace WebApi.BookOperations.CreateBooks
{
    // CreateBookCommand sınıfını Validate eder.
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            // Verilen parametre 0'dan daha büyük olmasını sağlar.
            //RuleFor(x=>x.Model.Genre).GreaterThan(0);
            RuleFor(x=>x.Model.PageCount).GreaterThan(0).WithMessage("Sayfa Sayısı 0'dan büyük olmalıdır!");
            // Bugünden daha küçük olmalı
            RuleFor(x=>x.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(x=>x.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}