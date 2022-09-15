using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.AuthorOperations.Commands.CreateAuthor;
using WebApi.Applications.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Applications.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Applications.AuthorOperations.CreateAuthor;
using WebApi.Applications.AuthorOperations.DeleteAuthor;
using WebApi.Applications.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Applications.AuthorOperations.Queries.GetAuthors;
using WebApi.Applications.BookOperations.Commands.CreateBooks;
using WebApi.Applications.BookOperations.Commands.DeleteBook;
using WebApi.Applications.BookOperations.Commands.UpdateBooks;
using WebApi.Applications.BookOperations.Queries.GetBookDetail;
using WebApi.Applications.BookOperations.Queries.GetBooks;
using WebApi.BookOperations.Queries.GetBookDetail;
using WebApi.DBOperations;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {   
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController (BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handler();
            return Ok(result);
        }
         
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetAuthorDetailViewModel result;
            
                GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
                query.AuthorId = id;
                GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handler();
           
           
            return Ok(result);
        }
        

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newBook)
        {
             CreateAuthorCommand cm = new CreateAuthorCommand(_context, _mapper);
            
                cm.Model = newBook;
                CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
                validator.ValidateAndThrow(cm);
                cm.Handle();
            
          
            return Ok();
            
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updatedBook)
        {
            UpdateAuthorCommand um = new UpdateAuthorCommand(_context);
            um.AuthorId = id;
            um.Model = updatedBook;

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(um);
            um.Handle();
             
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand dm = new DeleteAuthorCommand(_context);
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
                
                dm.AuthorId = id;
                validator.ValidateAndThrow(dm);
                dm.Handle();

            return Ok();
        }
    }   
}