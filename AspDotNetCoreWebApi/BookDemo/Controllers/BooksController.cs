using BookDemo.Data;
using BookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //Bu attribute ek bilgiler gelmesini sağlar
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name ="id")]int id) //Routedan gelecek
        {
            var book = ApplicationContext
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault(); //Tek bir kayıt yada default değerini dön
            
            if(book is null) //kitap null ise
            {
                return NotFound(); //404
            }

            return Ok(book);
        }

        [HttpPost]
        public  IActionResult CreateOneBook([FromBody]Book book)
        {
            try
            {
                if(book is null)
                {
                    return BadRequest();
                }
                ApplicationContext.Books.Add(book);
                return StatusCode(201,book);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
