using FluentValidation;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorById
{
    public class GetByIdAuthorQueryValidator:AbstractValidator<GetByIdAuthorQuery>
    {
        public GetByIdAuthorQueryValidator()
        {
            RuleFor(query=>query.authorId).GreaterThan(0);
            
        }

    }
}