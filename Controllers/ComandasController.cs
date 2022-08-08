using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvaSuficienciaWebII.Handler;
using ProvaSuficienciaWebII.Models;
using ProvaSuficienciaWebII.Views.Comandas;

namespace ProvaSuficienciaWebII.Controllers
{
    [ApiController]
    [Route("RestAPIFurb/[controller]")]

    [Authorize]
    public class ComandasController : ControllerBase
    {
        private readonly IComandasHandler _handler;

        public ComandasController(IComandasHandler repository)
        {
            _handler = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListarComandaViewModel>>> Listar()
        {
            var comandas =  await _handler.Listar();

            return Ok(comandas);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObterComandaViewModel>> GetByIdAsync(int id)
        {
            var comanda = await _handler.ObterPorId(id);
            return comanda;

        }

        [HttpPost]
        public async Task<ActionResult<SalvarComandaViewModel>> CadastrarComanda([FromBody] SalvarComanda comanda)
        {
            if(comanda.EhValido() != null)
            {
                return BadRequest (comanda.EhValido());
            }

            return Ok(await _handler.SalvarComanda(comanda));
           
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> AtualizarComanda([FromRoute] int id, [FromBody] AtualizarComanda comanda)
        {
            comanda.Id = id;

            if(comanda.EhValido() != null)
            {
                return BadRequest(comanda.EhValido());
            } 
            await _handler.AtualizarComanda(comanda);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<DeletarComandaViewModel>> RemoverComanda([FromRoute] int id)
        {
            if(id <= 0)
            {
                return BadRequest(new Models.Exceptions.Exception("Id", "Id deve ser maior que 0."));
            }
            return Ok(await _handler.DeletarComanda(id));
        }
    }
}
