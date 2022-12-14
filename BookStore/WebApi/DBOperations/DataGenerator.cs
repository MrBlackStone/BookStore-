using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any()) return;
                
                context.Authors.AddRange(
                    new Author{
                        authorName = "Andrew",
                        authorSurname = "Tate",
                        birthDate = new DateTime(1995,02,12)
                    },
                    new Author{
                        authorName = "William",
                        authorSurname = "Hitch",
                        birthDate = new DateTime(1965,05,07)
                    },
                    new Author{
                        authorName = "Henry",
                        authorSurname = "Ford",
                        birthDate = new DateTime(1986,07,09)
                    }
                );

                context.Genres.AddRange(
                    new Genre{
                        Name = "PersonalGrowth"
                    },
                    new Genre{
                        Name = "ScienceFiction"
                    },
                    new Genre{
                        Name = "Romance"
                    }

                );

                context.Books.AddRange(
                     new Book{
               // Id = 1,
                Title = "lean Startup",
                GenreId = 1, // Personal Growth
                PageCount = 200,
                PublishDate = new DateTime(2001,06,12),
                AuthorId = 1

                 },
                new Book{
                //Id = 2,
                Title = "Herland",
                GenreId = 2, // Science Fiction
                PageCount = 250,
                PublishDate = new DateTime(2010,06,12),
                AuthorId = 2

                },
                new Book{
               // Id = 3,
                Title = "Dune",
                GenreId = 2, // Science Fiction
                PageCount = 540,
                PublishDate = new DateTime(2001,12,21),
                AuthorId = 3

                }
                );
                context.SaveChanges();
            }
        }
    }
}