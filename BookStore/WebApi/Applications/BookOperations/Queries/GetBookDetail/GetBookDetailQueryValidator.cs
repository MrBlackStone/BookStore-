
using FluentValidation;
using WebApi.Applications.BookOperations.Queries.GetBookDetail;

namespace WebApi.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(x=> x.BookId)
            .GreaterThan(0).WithMessage("Lütfen 0'dan büyük bir sayı giriniz.")
            .NotEmpty().WithMessage("Lütfen boş bırakmayınız.");
        }
    }
}