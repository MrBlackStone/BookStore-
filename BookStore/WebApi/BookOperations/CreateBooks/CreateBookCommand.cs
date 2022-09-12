using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.GetBooks;
using WebApi.DBOperations;


namespace WebApi.BookOperations.CreateBooks
{
        public class CreateBookCommand
        {
            public CreateBookModel Model { get; set; }
            private readonly BookStoreDbContext _dbContext;
            private readonly IMapper _mapper;
            public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public void Handler()
            {
                var book = _dbContext.Books.SingleOrDefault(x=> x.Title == Model.Title);

                if(book is not null)
                    throw new InvalidOperationException("Kitap Zaten Mevcut");

                // Model ile gelen veriyi Book objesine maple.
                book = _mapper.Map<Book>(Model); //new Book();

                // book.Title = Model.Title;
                // book.GenreId = Model.Genre;
                // book.PageCount = Model.PageCount;
                // book.PublishDate = Model.PublishDate;
                
                _dbContext.Add(book);
                _dbContext.SaveChanges();
            }

        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId  { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
}