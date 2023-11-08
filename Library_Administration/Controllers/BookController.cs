using Library_Administration.Models;
using Library_Administration.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Library_Administration.Controllers
{
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        IBooksService booksService;

        public BookController(IBooksService service)
        {
            booksService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(booksService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(booksService.GetByIdBook(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Books books)
        {
            booksService.SaveBook(books);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Books books)
        {
            booksService.UpdateBook(id, books);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            booksService.DeleteBook(id);
            return Ok();
        }
    }
}
