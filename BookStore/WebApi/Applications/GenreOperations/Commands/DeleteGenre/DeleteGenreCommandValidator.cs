
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WebApi.Applications.GenreOperations.Commands.DeleteGenre;

namespace WebApi.Applications.GenreOperations.GetGenreDetail
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(x=> x.GenreId)
            .GreaterThan(0).WithMessage("0'dan farklı bir sayı giriniz.");
        }
    }
}