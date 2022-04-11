using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetByIdBookQuery
{
    public class GetByIdBookQuery
    {
        private readonly BookStoreDBContext _dbContext;
        public int bookId{get;set;}
        public GetByIdBookViewModel Model{get;set;}

        public GetByIdBookQuery(BookStoreDBContext dbContext)
        {
            _dbContext=dbContext;
        }

        public GetByIdBookViewModel Handle()
        {
            var book= _dbContext.Books.Where(book=>book.Id==bookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap Bulunamadı");
            GetByIdBookViewModel viewModel = new GetByIdBookViewModel();
            viewModel.Title=book.Title;
            viewModel.Genre=((GenreEnum)book.GenreId).ToString();
            viewModel.PageCont=book.PageCount;
            viewModel.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy");
            return viewModel;  
        }
    }

    public class GetByIdBookViewModel
    {
        public string Title { get; set; }
        public int PageCont { get; set; }
        public string PublishDate{get;set;}
        public string Genre{get;set;}
    }
}