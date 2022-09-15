using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;


namespace WebApi.Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext) => _dbContext = dbContext;

        public void Handler()
        {
             var book = _dbContext.Books.SingleOrDefault(x=>x.Id == BookId);
            if(book is null) // Book yoksa
                throw new InvalidOperationException("Silinecek Kitap Bulunamadı.");

                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
                
        }
    }

    
}