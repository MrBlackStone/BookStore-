using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;  
            _mapper = mapper;
        } 

        public GetBookDetailViewModel Handler()
        {
            var book = _dbContext.Books.Where(x=>x.Id == BookId).SingleOrDefault();

            if(book is null) throw new InvalidOperationException("Kitap mevcut değil");

            GetBookDetailViewModel gm = _mapper.Map<GetBookDetailViewModel>(book); //new GetBookDetailViewModel();
            
             
            // gm.Title = book.Title;
            // gm.PageCount = book.PageCount;
            // gm.Genre = ((GenreEnum)book.GenreId).ToString();
            // gm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");

            return gm;
        }
    }

    public class GetBookDetailViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}