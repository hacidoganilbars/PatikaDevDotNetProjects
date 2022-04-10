using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {

        private readonly BookStoreDBContext _dbContext;
        public GetBooksQuery(BookStoreDBContext dbContext)
        {
            _dbContext=dbContext;
        }

        public List<BookViewModel> Handle()
        {
            var bookList= _dbContext.Books.OrderBy(x=>x.Id).ToList<Book>();
            List<BookViewModel> vmBooks =new List<BookViewModel>();
            foreach (var book in bookList)
            {
                vmBooks.Add(new BookViewModel(){
                    Title=book.Title,
                    PageCont=book.PageCount,
                    Genre=((GenreEnum)book.GenreId).ToString(),
                    PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy")
                });
            }
            return vmBooks;
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCont { get; set; }
        public string PublishDate{get;set;}
        public string Genre{get;set;}
    }
}