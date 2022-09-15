
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
           public int AuthorId { get; set; }

           private readonly BookStoreDbContext _dbContext;
           
           public UpdateAuthorModel Model;

           public UpdateAuthorCommand(BookStoreDbContext context)
           {
                _dbContext = context;
           }
           public void Handle()
           {

                var author = _dbContext.Authors.Where(x=>x.authorId == AuthorId).SingleOrDefault();

                if(author is null) throw new InvalidOperationException("Yazar bulunamadı.");

                
                author.authorName = Model.authorName = default ? author.authorName : Model.authorName;
                author.authorSurname = Model.authorSurname = default ? author.authorName : Model.authorSurname;
                
                author.birthDate = Model.birthDate = default ? author.birthDate : Model.birthDate;
                _dbContext.SaveChanges();
                
           }

    }
    public class UpdateAuthorModel
    {
        public string authorName { get; set; }
        public string  authorSurname { get; set; }
        public DateTime birthDate { get; set; }
    }
}