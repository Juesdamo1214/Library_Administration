using Library_Administration.Models;
using Library_Administration.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Administration.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        IAuthorService authorService;

        public AuthorController(IAuthorService service)
        {
            authorService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(authorService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Authors authors)
        {
            authorService.SaveAuthor(authors);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Authors authors)
        {
            authorService.UpdateAuthor(id, authors);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            authorService.DeleteAuthor(id);
            return Ok();
        }
    }
}
