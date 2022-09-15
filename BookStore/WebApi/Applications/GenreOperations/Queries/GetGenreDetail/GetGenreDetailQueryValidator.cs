
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WebApi.DBOperations;

namespace WebApi.Applications.GenreOperations.GetGenreDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(x=> x.GenreId).GreaterThan(0).WithMessage("Lütfen 0'dan büyük bir sayı yazınız.");
        }
    }
}