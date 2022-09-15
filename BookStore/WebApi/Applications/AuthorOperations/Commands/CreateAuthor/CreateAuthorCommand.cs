using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Entities;
namespace WebApi.Applications.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateAuthorModel Model { get; set; }
        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.Where(x=> x.authorName == Model.authorName).SingleOrDefault();

            if(author is not null) throw new InvalidOperationException("Yazar mevcut");

            author = _mapper.Map<Author>(Model);
            _dbContext.Add(author);
            _dbContext.SaveChanges();
        }
    }

    public class CreateAuthorModel
    {
        public string authorName { get; set; }
        public string  authorSurname { get; set; }
        public DateTime birthDate { get; set; }
    }
}