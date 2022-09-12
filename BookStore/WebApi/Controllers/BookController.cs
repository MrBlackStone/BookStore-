using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBooks;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;

using WebApi.BookOperations.UpdateBooks;
using WebApi.DBOperations;


namespace WebApi.AddControllers
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
           try
           {
                GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
                query.BookId = id;
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handler();
           }
           catch(Exception ex)
           {
                return BadRequest(ex.Message);
           }
           
            return Ok(result);
        }
        

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
             CreateBookCommand cm = new CreateBookCommand(_context, _mapper);
            try
            {
                cm.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(cm);
                cm.Handler();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
            return Ok();
            
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand um = new UpdateBookCommand(_context);
            try
            {
                um.BookId = id;
                um.Model = updatedBook;
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(um);
                um.Handler();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
             
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand dm = new DeleteBookCommand(_context);

            try
            {
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                
                dm.BookId = id;
                validator.ValidateAndThrow(dm);
                dm.Handler();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }   
}