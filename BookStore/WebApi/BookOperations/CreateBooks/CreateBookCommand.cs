using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.GetBooks;
using WebApi.DBOperations;


namespace WebApi.BookOperations.CreateBooks
{
        public class CreateBookCommand
        {
            public CreateBookModel Model { get; set; }
            private readonly BookStoreDbContext _dbContext;
            public CreateBookCommand(BookStoreDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public void Handler()
            {
                var book = _dbContext.Books.SingleOrDefault(x=> x.Title == Model.Title);

                if(book is not null)
                    throw new InvalidOperationException("Kitap Zaten Mevcut");

                book = new Book();

                book.Title = Model.Title;
                book.GenreId = Model.Genre;
                book.PageCount = Model.PageCount;
                book.PublishDate = Model.PublishDate;
                
                _dbContext.Add(book);
                _dbContext.SaveChanges();
            }

        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int Genre { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
}