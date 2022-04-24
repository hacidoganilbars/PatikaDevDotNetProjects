using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetByIdGenre
{
    public class GetByIdGenreQuery
    {
        public int GenreId{get;set;}
        public readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public GetByIdGenreQuery(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public  GetByIdGenreViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id==GenreId);
            if(genre is null){
                throw new InvalidOperationException("Kitap Türü Bulunamadı!!");
            }
            GetByIdGenreViewModel returnObj=_mapper.Map<GetByIdGenreViewModel>(genre);
            return returnObj;
        }
    }

    public class GetByIdGenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}