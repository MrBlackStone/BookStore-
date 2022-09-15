using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;


namespace WebApi.Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x=>x.BookId).GreaterThan(0).WithMessage("Lütfen 0'dan büyük bir sayı giriniz!");
        }
    }
}