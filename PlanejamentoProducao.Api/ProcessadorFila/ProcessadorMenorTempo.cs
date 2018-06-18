using PlanejamentoProducao.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlanejamentoProducao.Api.ProcessadorFila
{
    public class ProcessadorMenorTempo : IProcessadorFila
    {
        public IEnumerable<Processo> ProcessarFila(IEnumerable<Processo> processos)
        {
            return processos.OrderBy(p => p.TempoExecucao).ToList();
        }
    }
}
