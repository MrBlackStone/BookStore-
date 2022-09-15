
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WebApi.Applications.GenreOperations.Commands.CreateGenre;

namespace WebApi.Applications.GenreOperations.GetGenreDetail
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(x=> x.Model.Name)
            .MinimumLength(4).WithMessage("4 karakterden az girmeyiniz.")
            .NotEmpty().WithMessage("İsim alanı boş bırakılamaz.");
        }
    }
}