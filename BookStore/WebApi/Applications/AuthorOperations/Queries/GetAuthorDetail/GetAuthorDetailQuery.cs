using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Applications.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }
        public GetAuthorDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;  
            _mapper = mapper;
        } 

        public GetAuthorDetailViewModel Handler()
        {

            var author = _dbContext.Authors.Where(x=>x.authorId == AuthorId).SingleOrDefault();
            if(author is null) throw new InvalidOperationException("Yazar mevcut değil");

            GetAuthorDetailViewModel gm = _mapper.Map<GetAuthorDetailViewModel>(author); 
            

            return gm;
        }
    }

    public class GetAuthorDetailViewModel
    {
        public string authorName { get; set; }
        public string  authorSurname { get; set; }
        public DateTime birthDate { get; set; }
    }
}