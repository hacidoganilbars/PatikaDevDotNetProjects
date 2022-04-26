using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider){
            using(var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre(){
                        Name="Personal Growth",
                    },
                    new Genre(){
                        Name="Science Fiction",
                    },
                    new Genre(){
                        Name="Romance",
                    }
                );
                
                context.Books.AddRange(
                    new Book(){
                    //Id=1,
                        Title="Lean Startup",
                        GenreId=1,//Personal Growth
                        PageCount=200,
                        PublishDate=new DateTime(2001,06,12)
                    },
                    new Book(){
                        //Id=2,
                        Title="Herland",
                        GenreId=2,//Science Finction
                        PageCount=250,
                        PublishDate=new DateTime(2010,05,23)
                    },
                    new Book(){
                        //Id=3,
                        Title="Dune",
                        GenreId=2,//Science Finction
                        PageCount=540,
                        PublishDate=new DateTime(2001,12,21)
                    }
                );
                context.Authors.AddRange(
                    new Author(){
                        Name="Mahmut",
                        Surname="Mahmutsoy",
                        BookId=1,
                        BirthDate=new DateTime(1980,06,12),   
                    },
                    new Author(){
                        Name="Ahmet",
                        Surname="Ahmetsoy",
                        BookId=2,
                        BirthDate=new DateTime(1968,07,22),   
                    },new Author(){
                        Name="Özlem",
                        Surname="Özlemsoy",
                        BookId=3,
                        BirthDate=new DateTime(1977,04,15),   
                    }

                );
                context.SaveChanges();
            }
        }
    }
}