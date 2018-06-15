using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanejamentoProducao.Api;
using PlanejamentoProducao.Api.Models;
using PlanejamentoProducao.Web.Models;

namespace PlanejamentoProducao.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProducaoManager _producaoManager;

        public HomeController(IProducaoManager producaoManager)
        {
            _producaoManager = producaoManager;
        }

        public IActionResult Index()
        {
            _producaoManager.AdicionarProcesso(new Processo()
            {
                Identificador = "Refile Manual",
                TempoExecucao = 60,
                CustoPorHora = 30
            });

            _producaoManager.AdicionarProcesso(new Processo()
            {
                Identificador = "Impressão",
                TempoExecucao = 30,
                CustoPorHora = 40
            });

            _producaoManager.AdicionarProcesso(new Processo()
            {
                Identificador = "Acabamento",
                TempoExecucao = 40,
                CustoPorHora = 20
            });

            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
