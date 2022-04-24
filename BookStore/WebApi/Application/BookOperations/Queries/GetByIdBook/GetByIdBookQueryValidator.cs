using FluentValidation;

namespace WebApi.Application.BookOperations.Queries.GetByIdBook
{
    public class GetByIdBookQueryValidator : AbstractValidator<GetByIdBookQuery>
    {

        public GetByIdBookQueryValidator()
        {
            RuleFor(query=>query.bookId).GreaterThan(0);
            
        }

    }

}