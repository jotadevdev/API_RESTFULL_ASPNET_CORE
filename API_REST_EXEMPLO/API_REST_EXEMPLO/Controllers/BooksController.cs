using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API_REST_EXEMPLO.Controllers
{

    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        // api/Books/v1
        [HttpGet("v1")]
        public IActionResult Get()
        {
            return Ok();
        }

        // api/Books/v1/5
        [HttpGet("v1/{id}")]
        public IActionResult Get(long id)
        {
            return Ok();
        }

        // POST api/Books/v1
        [HttpPost("v1")]
        public IActionResult Post([FromBody] Book book)
        {
            return Ok();

        }

        // PUT api/Books/v1
        [HttpPut("v1")]
        public IActionResult Put([FromBody] Book book)
        {
            if (person == null) return BadRequest();
            var alteraItem = _personService.Update(person);
            if (person == null) return NoContent();
            return new ObjectResult(alteraItem);
        }

    }
}
