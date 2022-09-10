using System;
using System.Collections.Generic;
using System.Linq;
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

        public BookController (BookStoreDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksByQuery query = new GetBooksByQuery(_context);
            var result = query.Handler();
            return Ok(result);
        }
         
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookDetailViewModel result;
           try
           {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
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
             CreateBookCommand cm = new CreateBookCommand(_context);
            try
            {
                cm.Model = newBook;
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
                dm.BookId = id;
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