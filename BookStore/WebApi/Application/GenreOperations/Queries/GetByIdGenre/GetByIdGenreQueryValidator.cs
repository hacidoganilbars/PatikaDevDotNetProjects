using FluentValidation;

namespace WebApi.Application.GenreOperations.Queries.GetByIdGenre
{
    public class GetByIdGenreQueryValidator:AbstractValidator<GetByIdGenreQuery>
    {
        public GetByIdGenreQueryValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);

        }

    }

}