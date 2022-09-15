
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
           public int GenreId { get; set; }

           private readonly BookStoreDbContext _dbContext;
           
           public UpdateGenreModel Model;

           public UpdateGenreCommand(BookStoreDbContext context)
           {
            _dbContext = context;
           }
           public void Handle()
           {
                var genre = _dbContext.Genres.SingleOrDefault(x=> x.Id == GenreId);

                if(genre is null) throw new InvalidOperationException("Kitap türü bulunamadı.");

                // Başka bir Id'ye ait türde varsa
                // En az 1 tane veri varsa True döner.
                if(_dbContext.Genres.Any(x=> x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId)) 
                    throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcut.");

                genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name ;
                genre.IsActive = Model.IsActive;
                _dbContext.SaveChanges();
                
           }

    }
    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}