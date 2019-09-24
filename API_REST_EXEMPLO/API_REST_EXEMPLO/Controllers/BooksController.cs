using API_REST_EXEMPLO.Business;
using API_REST_EXEMPLO.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_REST_EXEMPLO.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:ApiVersion}")]
    public class BooksController : ControllerBase
    {

        private IBooksBusiness _BookService;

        public BooksController(IBooksBusiness BookService)
        {
            _BookService = BookService;
        }

        // api/Books/v1
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_BookService.FindAll());
        }

        // api/Books/v1/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Books book = _BookService.FindById(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        // POST api/Books/v1
        [HttpPost]
        public IActionResult Post([FromBody] Books book)
        {
            if (book == null) return BadRequest();
            return Ok(_BookService.Create(book));

        }

        // PUT api/Books/v1
        [HttpPut]
        public IActionResult Put([FromBody] Books book)
        {
            if (book == null) return BadRequest();
            var alteraItem = _BookService.Update(book);
            if (book == null) return NoContent();
            return new ObjectResult(alteraItem);
        }

        // DELETE api/Persons/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();
            _BookService.Delete(id);

            //NoContent qdo não retorna nada (204 na tela)
            return NoContent();
        }
    }
}
