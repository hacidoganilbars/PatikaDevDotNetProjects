using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetByIdBookQuery;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.AddControllers{

    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase
    {

        private readonly BookStoreDBContext _context;

        public BookController(BookStoreDBContext context)
        {
            _context=context;
        }
        // private static List<Book> BookList = new List<Book>(){
        //     new Book(){
        //         Id=1,
        //         Title="Lean Startup",
        //         GenreId=1,//Personal Growth
        //         PageCount=200,
        //         PublishDate=new DateTime(2001,06,12)
        //     },
        //     new Book(){
        //         Id=2,
        //         Title="Herland",
        //         GenreId=2,//Science Finction
        //         PageCount=250,
        //         PublishDate=new DateTime(2010,05,23)
        //     },
        //     new Book(){
        //         Id=3,
        //         Title="Dune",
        //         GenreId=2,//Science Finction
        //         PageCount=540,
        //         PublishDate=new DateTime(2001,12,21)
        //     }
        // };


        [HttpGet]
        public IActionResult GetBooks()
         {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
         }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetByIdBookQuery query= new GetByIdBookQuery(_context);
            GetByIdBookViewModel result;
            try
            {
                query.bookId=id;
                result = query.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }


        // [HttpGet]
        // public Book? Get([FromQuery] string id){
        //     var book = BookList.Where(book=>book.Id==Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            
            try
            {
                command.BookId = id;
                command.Model=updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand deleteBook = new DeleteBookCommand(_context);
            try
            {
                deleteBook.bookId=id;
                deleteBook.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }

    }
}