using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDBContext _dbcontext;
        public int authorId{get;set;}
        public DeleteAuthorCommand(BookStoreDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

     
        public void Handle()
        {
            var author = _dbcontext.Authors.SingleOrDefault(x=>x.Id==authorId);
            if(author is null)
            {
                throw new InvalidOperationException("Silinecek Yazar Bulunamadı!!");
            }
            if(author.Book.Id == 0){
                _dbcontext.Authors.Remove(author);
            }
            
            _dbcontext.SaveChanges();
        }


    }

}