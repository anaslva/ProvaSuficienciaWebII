using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProvaSuficienciaWebII.Data.Context;
using ProvaSuficienciaWebII.Handler;
using ProvaSuficienciaWebII.Models;
using ProvaSuficienciaWebII.Views.Comandas;

namespace ProvaSuficienciaWebII.Controllers
{
    [ApiController]
    [Route("[controller]")]

    [Authorize]
    public class ComandasController : ControllerBase
    {
        private readonly IComandasHandler _handler;

        public ComandasController(IComandasHandler repository)
        {
            _handler = repository;
        }

        [HttpGet]
        public Task<List<ListarComandaViewModel>> Listar()
        {
            var comandas =  _handler.Listar();

            return comandas;

        }

        [HttpGet("{id}")]
        public async Task<ObterComandaViewModel> GetByIdAsync(int id)
        {
            var comanda = await _handler.ObterPorId(id);
            return comanda;

        }

        [HttpPost]
        public Task<SalvarComandaViewModel> CadastrarComanda([FromBody] SalvarComanda comanda)
        {
            return _handler.SalvarComanda(comanda);
        }

        [HttpPut]
        [Route("{id}")]
        public Task AtualizarComanda([FromRoute] int id, [FromBody] AtualizarComanda comanda)
        {
            comanda.Id = id;
            return _handler.AtualizarComanda(comanda);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<DeletarComandaViewModel> RemoverComanda([FromRoute] int id)
        {
            return _handler.DeletarComanda(id);
        }
    }
}
