using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDBContext _dbContext;

        public int AuthorId{get; set;}

        public UpdateAuthorModel Model{get; set;}

        public UpdateAuthorCommand(BookStoreDBContext dBContext)
        {
            _dbContext=dBContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=>x.Id==AuthorId);
            if(author is null)
            {
                throw new InvalidOperationException("Güncellenecek Yazar Bulunamadı!!");
            }
            author.BookId = Model.BookId !=default?Model.BookId:author.BookId;
            author.Name = Model.Name !=default?Model.Name:author.Name;
            author.Surname = Model.Surname !=default?Model.Surname:author.Surname;
            // author.BirthDate = Model.BirthDate !=default?Model.BirthDate:author.BirthDate;
            _dbContext.SaveChanges();
        }
    
    }
    public class UpdateAuthorModel
    {
        public string Name{get;set;}
        public string Surname{get;set;}
        public int BookId{get;set;}
    }

}