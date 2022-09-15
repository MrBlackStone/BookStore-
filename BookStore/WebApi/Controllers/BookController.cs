using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
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
    public class BookController : ControllerBase
    {   
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController (BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksByQuery query = new GetBooksByQuery(_context, _mapper);
            var result = query.Handler();
            return Ok(result);
        }
         
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookDetailViewModel result;
            
                GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
                query.BookId = id;
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handler();
           
           
            return Ok(result);
        }
        

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
             CreateBookCommand cm = new CreateBookCommand(_context, _mapper);
            
                cm.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(cm);
                cm.Handler();
            
          
            return Ok();
            
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand um = new UpdateBookCommand(_context);
            um.BookId = id;
            um.Model = updatedBook;

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(um);
            um.Handler();
             
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand dm = new DeleteBookCommand(_context);
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                
                dm.BookId = id;
                validator.ValidateAndThrow(dm);
                dm.Handler();

            return Ok();
        }
    }   
}