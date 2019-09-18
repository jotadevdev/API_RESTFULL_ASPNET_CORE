using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_REST_EXEMPLO.Model;
using API_REST_EXEMPLO.Business;
using Microsoft.AspNetCore.Mvc;

namespace API_REST_EXEMPLO.Controllers
{

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:ApiVersion}")]
    [ApiController]
    public class PersonsController : ControllerBase
    {

        private IPersonBusiness _personService;

        public PersonsController(IPersonBusiness personService)
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

        // PUT api/Persons
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            var alteraItem = _personService.Update(person);
            if (person == null) return NoContent();
            return new ObjectResult(alteraItem);
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
