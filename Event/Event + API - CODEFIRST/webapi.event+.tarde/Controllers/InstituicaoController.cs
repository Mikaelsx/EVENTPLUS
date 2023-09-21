
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository ctx { get; set; }

        public InstituicaoController()
        {
            ctx = new InstituicaoRepository();
        }

        // Funcionando
        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                ctx.Cadastrar(instituicao);

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
        public IActionResult Put(Guid id, Instituicao instituicao)
        {
            try
            {
                ctx.Atualizar(id, instituicao);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
    }
}
