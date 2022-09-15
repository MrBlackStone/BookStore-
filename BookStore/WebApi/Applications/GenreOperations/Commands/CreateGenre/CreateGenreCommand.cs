using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public CreateGenreCommand(BookStoreDbContext context)
        {
            _dbContext = context;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x=>x.Name == Model.Name);

            if(genre is not null) 
                throw new InvalidOperationException("Genre Mevcut");

            genre = new Genre();
            genre.Name = Model.Name;
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}