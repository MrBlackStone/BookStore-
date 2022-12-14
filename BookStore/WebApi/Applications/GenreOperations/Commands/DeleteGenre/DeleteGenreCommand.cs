
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
           public int GenreId { get; set; }

           private readonly BookStoreDbContext _dbContext;

           public DeleteGenreCommand(BookStoreDbContext context) => _dbContext = context;
           public void Handle()
           {
                var genre = _dbContext.Genres.SingleOrDefault(x=> x.Id == GenreId);

                if(genre is null) throw new InvalidOperationException("Kitap türü bulunamadı.");

                _dbContext.Genres.Remove(genre);
                _dbContext.SaveChanges();
           }
    }
}