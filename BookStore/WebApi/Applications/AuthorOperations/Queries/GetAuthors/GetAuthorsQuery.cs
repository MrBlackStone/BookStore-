using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery 
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetAuthorsViewModel> Handler()
        {
            var authorlist = _dbContext.Authors.OrderBy(x=>x.authorId).ToList<Author>();
            List<GetAuthorsViewModel> vm = _mapper.Map<List<GetAuthorsViewModel>>(authorlist);//new List<BooksViewModel>();
            return vm;

            
        }
    }

    public class GetAuthorsViewModel
    {
        public string authorName { get; set; }
        public string  authorSurname { get; set; }
        public DateTime birthDate { get; set; }
    }
}