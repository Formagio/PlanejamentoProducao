using Microsoft.AspNetCore.Mvc;
using PlanejamentoProducao.Api;
using PlanejamentoProducao.Api.Models;
using PlanejamentoProducao.Api.ProcessadorFila;
using System;
using System.Collections.Generic;
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
        public IEnumerable<string> Get()
        {
            try
            {
                _gerenciadorFila.AdicionarProcesso(new Processo()
                {
                    Identificador = "Refile Manual",
                    TempoExecucao = 60,
                    CustoPorHora = 30
                });

                _gerenciadorFila.AdicionarProcesso(new Processo()
                {
                    Identificador = "Impressão",
                    TempoExecucao = 30,
                    CustoPorHora = 40
                });

                _gerenciadorFila.AdicionarProcesso(new Processo()
                {
                    Identificador = "Acabamento",
                    TempoExecucao = 40,
                    CustoPorHora = 20
                });
                
                var filaMenorTempo = _gerenciadorFila.ProcessarFila(new ProcessadorMenorTempo());
                var filaMenorCusto = _gerenciadorFila.ProcessarFila(new ProcessadorMenorCusto());

                return filaMenorTempo.Select(f => f.Identificador);
            }
            catch (ArgumentException)
            {
            }

            return new string[] { "value1", "value2" };
        }

        // POST: api/GerenciadorProducao
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
