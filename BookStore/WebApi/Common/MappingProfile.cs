using AutoMapper;
using WebApi.Application.AuthorOperations.Queries.GetAuthorById;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.BookOperations.Queries.GetByIdBook;
using WebApi.Application.GenreOperations.Queries.GetByIdGenre;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();
            // CreateMap<Book,GetByIdBookViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,GetByIdBookViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>(src.Genre.Name)));
            CreateMap<Book,BookViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>(src.Genre.Name)));
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GetByIdGenreViewModel>();
            CreateMap<Author,AuthorViewModel>().ForMember(dest=>dest.Book,opt=>opt.MapFrom(src=>(src.Book.Title)));
            CreateMap<Author,GetByIdAuthorViewModel>().ForMember(dest=>dest.Book,opt=>opt.MapFrom(src=>(src.Book.Title)));
        }
    }
}