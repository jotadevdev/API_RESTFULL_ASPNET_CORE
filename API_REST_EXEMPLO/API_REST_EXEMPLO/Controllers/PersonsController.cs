using Microsoft.AspNetCore.Mvc;
using API_REST_EXEMPLO.Data.VO;
using API_REST_EXEMPLO.Business;
using Tapioca.HATEOAS;

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
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET api/Persons/5
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            PersonVO PersonVO = _personService.FindById(id);
            if (_personService.FindById(id) == null)
            {
                return NotFound();
            }
            return Ok(PersonVO);
        }   

        // POST api/Persons
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO PersonVO)
        {
            if (PersonVO == null) return BadRequest();
            return new ObjectResult(_personService.Create(PersonVO));

        }

        // PUT api/Persons
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO PersonVO)
        {
            if (PersonVO == null) return BadRequest();
            var alteraItem = _personService.Update(PersonVO);
            if (PersonVO == null) return NoContent();
            return new ObjectResult(alteraItem);
        }

        // DELETE api/Persons/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();
            _personService.Delete(id);

            //NoContent qdo não retorna nada (204 na tela)
            return NoContent();
        }
    }
}
