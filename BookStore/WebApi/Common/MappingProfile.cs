
using AutoMapper;
using WebApi.BookOperations.CreateBooks;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBooks;
using static WebApi.BookOperations.CreateBooks.CreateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create Book Model objesi  Book objesine Maplenebilir.
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetBookDetailViewModel>().ForMember(dest=> dest.Genre, opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));        }
    }
}