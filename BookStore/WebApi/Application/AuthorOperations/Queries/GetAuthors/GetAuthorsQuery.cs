using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDBContext _dbContext;
        
        private readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle(){
            var authorList = _dbContext.Authors.Include(x =>x.Book).OrderBy(x => x.Id).ToList<Author>();
            List<AuthorViewModel> vmAuthors = _mapper.Map<List<AuthorViewModel>>(authorList);
            return vmAuthors;
        }


    }
    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string Book { get; set; }
    }
}