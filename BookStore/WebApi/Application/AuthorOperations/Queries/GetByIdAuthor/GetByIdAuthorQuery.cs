using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorById
{
    public class GetByIdAuthorQuery
    {
        private readonly BookStoreDBContext _dbContext;
         public int authorId{get;set;}
        public GetByIdAuthorViewModel Model{get;set;}
        private readonly IMapper _mapper;

        public GetByIdAuthorQuery(BookStoreDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetByIdAuthorViewModel Handle()
        {
            // var book= _dbContext.Books.Include(x=>x.Genre).Where(book=>book.Id==bookId).SingleOrDefault()
            var author= _dbContext.Authors.Include(x=>x.Book).Where(author=>author.Id==authorId).SingleOrDefault();
            if(author is null)
            {
                throw new InvalidOperationException("Yazar Bulunamadı");
            }
            GetByIdAuthorViewModel viewModel= _mapper.Map<GetByIdAuthorViewModel>(author);
            return viewModel;
        }

    }



    public class GetByIdAuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string Book { get; set; }

    }
}