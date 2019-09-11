using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_REST_EXEMPLO.Model;
using API_REST_EXEMPLO.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_REST_EXEMPLO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {

        private IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET api/Persons
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET api/Persons/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Person person = _personService.FindById(id);
            if (_personService.FindById(id) == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        // POST api/Persons
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Create(person));

        }

        // PUT api/Persons/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Update(person));
        }

        // DELETE api/Persons/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();
            _personService.Delete(id);

            //NoContent qdo não retorna nada (204 na tela)
            return NoContent();
        }
    }
}
