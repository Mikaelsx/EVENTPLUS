using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.manha.Repositories;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository ctx;

        public TipoEventoController()
        {
            ctx = new TipoEventoRepository();
        }

        // Funcionando
        [HttpPost]
        public IActionResult Post(TipoEvento tipoEvento)
        {
            try
            {
                ctx.Cadastrar(tipoEvento);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Funcionando
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(ctx.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Funcionando
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                ctx.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Funcionando
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(ctx.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Falha
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                ctx.Atualizar(id, tipoEvento);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
    }
}
