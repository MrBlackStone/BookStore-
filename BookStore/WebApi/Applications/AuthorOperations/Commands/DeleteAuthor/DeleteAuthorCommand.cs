using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Entities;
namespace WebApi.Applications.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _dbContext = context;
            
        }

        public void Handle()
        {
            var bookAuthor = _dbContext.Books.Where(x=>x.AuthorId == AuthorId).SingleOrDefault();

            if(bookAuthor is not null) throw new InvalidOperationException("Yazarın bir veya birden fazla kitabı olduğu için silinemez.");
            
            var author = _dbContext.Authors.SingleOrDefault(x=>x.authorId == AuthorId);

            if(author is null) throw new InvalidOperationException("Yazar bulunamadı.");
            
            _dbContext.Remove(author);
            _dbContext.SaveChanges();
        }
    }

    
}