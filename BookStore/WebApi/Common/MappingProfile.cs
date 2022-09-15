
using AutoMapper;
using WebApi.Applications.AuthorOperations.CreateAuthor;
using WebApi.Applications.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Applications.AuthorOperations.Queries.GetAuthors;
using WebApi.Applications.BookOperations.Commands.CreateBooks;
using WebApi.Applications.BookOperations.Queries.GetBookDetail;
using WebApi.Applications.BookOperations.Queries.GetBooks;
using WebApi.Applications.GenreOperations.GetGenreDetail;
using WebApi.Applications.GenreOperations.Queries.GetGenres;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create Book Model objesi  Book objesine Maplenebilir.
            CreateMap<CreateBookModel, Book>();

            CreateMap<Book, GetBookDetailViewModel>()
            .ForMember(dest=> dest.Genre, opt=>opt.MapFrom(src=> src.Genre.Name))
            .ForMember(dest=>dest.AuthorName, opt=>opt.MapFrom(src=> src.Author.authorName))
            .ForMember(dest=> dest.AuthorSurname, opt=> opt.MapFrom(src=> src.Author.authorSurname));

            CreateMap<Book, BooksViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src=> src.Genre.Name))
            .ForMember(dest=>dest.AuthorName, opt=> opt.MapFrom(src=> src.Author.authorName))
            .ForMember(dest=> dest.AuthorSurname, opt=> opt.MapFrom(src=> src.Author.authorSurname));      
            
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();

            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, GetAuthorDetailViewModel>();
            CreateMap<Author, GetAuthorsViewModel>();
            
        }
    }
}