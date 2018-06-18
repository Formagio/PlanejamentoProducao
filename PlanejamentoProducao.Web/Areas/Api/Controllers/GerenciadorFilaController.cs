using Microsoft.AspNetCore.Mvc;
using PlanejamentoProducao.Api;
using PlanejamentoProducao.Api.Models;
using PlanejamentoProducao.Api.ProcessadorFila;
using PlanejamentoProducao.Web.Areas.Api.Models;
using System;
using System.Linq;

namespace PlanejamentoProducao.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerenciadorFilaController : ControllerBase
    {
        private readonly IGerenciadorFila _gerenciadorFila;

        public GerenciadorFilaController(IGerenciadorFila gerenciadorFila)
        {
            _gerenciadorFila = gerenciadorFila;
        }

        // GET: api/GerenciadorProducao
        [HttpGet]
        public IActionResult Get()
        {
            var filaMenorTempo = _gerenciadorFila.ProcessarFila(new ProcessadorMenorTempo());
            var filaMenorCusto = _gerenciadorFila.ProcessarFila(new ProcessadorMenorCusto());

            return Ok(new GerenciadorFilaViewModel()
            {
                FilaMenorTempoEspera = filaMenorTempo.Select(f => f.Identificador),
                FilaMenorCustoEspera = filaMenorCusto.Select(f => f.Identificador)
            });
        }

        // POST: api/GerenciadorProducao
        [HttpPost]
        public IActionResult Post(Processo value)
        {
            try
            {
                _gerenciadorFila.IncluirProcesso(value);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
