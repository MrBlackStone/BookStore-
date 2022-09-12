using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBooks
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext dbContext) => _dbContext = dbContext;

        public void Handler()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Id == BookId);

            if(book is null)
                throw new InvalidOperationException("Kitap Mevcut Değil");

                 book.GenreId = Model.Genre != default ? Model.Genre : book.GenreId; // Veri varsa ve doldurulmuşsa
                 book.Title = Model.Title !=default ? Model.Title : book.Title; 
        
                 _dbContext.SaveChanges();
        }

    }

    public class UpdateBookModel
    {
            public string Title { get; set; }
            public int Genre { get; set; }
    }
}