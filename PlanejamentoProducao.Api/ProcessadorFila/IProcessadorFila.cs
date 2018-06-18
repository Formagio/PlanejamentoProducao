using PlanejamentoProducao.Api.Models;
using System.Collections.Generic;

namespace PlanejamentoProducao.Api.ProcessadorFila
{
    public interface IProcessadorFila
    {
        IEnumerable<Processo> ProcessarFila(IEnumerable<Processo> processos);
    }
}
