using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProvaSuficienciaWebII.Data.Context;
using ProvaSuficienciaWebII.Models;
using ProvaSuficienciaWebII.Repositories;
using ProvaSuficienciaWebII.Views.Comandas;

namespace ProvaSuficienciaWebII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComandasController : ControllerBase
    {
        private readonly IComandasRepository _repository;

        public ComandasController(IComandasRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Task<List<ListarComandaViewModel>> Listar()
        {
            var comandas =  _repository.Listar();

            return comandas;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var comanda = await _repository.ObterPorId(id);
            return Ok(comanda);

        }

        [HttpPost]
        public Task<SalvarComandaViewModel> CadastrarComanda([FromBody] Comanda comanda)
        {
            return _repository.SalvarComanda(comanda);
        }
    }
}
