using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API_REST_EXEMPLO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {

        // GET api/Calculadora/Somar/5/5
        [HttpGet("Somar/{priNumero}/{segNumero}")]
        public ActionResult<string> Somar(string priNumero, string segNumero)
        {
            if (Isnumeric(priNumero) && Isnumeric(segNumero))
            {
                return Ok(toDecimal(priNumero) + toDecimal(segNumero));
            }

            return BadRequest("Invalid Imput");
        }

        // GET api/Calculadora/Subtrair/5/5
        [HttpGet("Subtrair/{priNumero}/{segNumero}")]
        public ActionResult<string> Subtrair(string priNumero, string segNumero)
        {
            if (Isnumeric(priNumero) && Isnumeric(segNumero))
            {
                return Ok(toDecimal(priNumero) - toDecimal(segNumero));
            }

            return BadRequest("Invalid Imput");
        }

        // GET api/Calculadora/Dividir/5/5
        [HttpGet("Dividir/{priNumero}/{segNumero}")]
        public ActionResult<string> Dividir(string priNumero, string segNumero)
        {
            if (Isnumeric(priNumero) && Isnumeric(segNumero))
            {
                return Ok(toDecimal(priNumero) / toDecimal(segNumero));
            }

            return BadRequest("Invalid Imput");
        }

        // GET api/Calculadora/Multiplicar/5/5
        [HttpGet("Multiplicar/{priNumero}/{segNumero}")]
        public ActionResult<string> Multiplicar(string priNumero, string segNumero)
        {
            if (Isnumeric(priNumero) && Isnumeric(segNumero))
            {
                return Ok(toDecimal(priNumero) / toDecimal(segNumero));
            }

            return BadRequest("Invalid Imput");
        }

        private decimal toDecimal(string Numero)
        {
            decimal valor;

            if (Decimal.TryParse(Numero, out valor))
            {
                return valor;
            }
            return 0;
        }

        private bool Isnumeric(string Numero)
        {
            double tentaConvert;
            return Double.TryParse(Numero, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out tentaConvert);

        }
    }
}
