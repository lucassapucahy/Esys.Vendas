using Microsoft.AspNetCore.Mvc;

namespace Esys.Vendas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {

        [HttpGet("produto/{id}")]
        public IActionResult GetByProduto(int produtoId)
        {
            return Ok();
        }

        [HttpGet("usuario/{id}")]
        public IActionResult GetByUser(int usuarioId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
