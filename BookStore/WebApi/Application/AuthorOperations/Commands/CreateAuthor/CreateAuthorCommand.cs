using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model{get; set;}
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(BookStoreDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=>x.Name==Model.Name && x.Surname==Model.Surname);
            if(author is not null){
                throw new InvalidOperationException("Yazar Zaten Mevcut!");
            }
            author=_mapper.Map<Author>(Model);
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();

        }
    
    }

    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname{get;set;}
        public int BookId{get;set;}
        public DateTime BirthDate{get;set;}
    }

}