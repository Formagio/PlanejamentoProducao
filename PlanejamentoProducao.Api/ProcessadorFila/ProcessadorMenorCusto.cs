using Combinatorics.Collections;
using PlanejamentoProducao.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlanejamentoProducao.Api.ProcessadorFila
{
    public class ProcessadorMenorCusto : IProcessadorFila
    {
        public IEnumerable<Processo> ProcessarFila(IEnumerable<Processo> processos)
        {
            var indices = Enumerable.Range(0, processos.Count()).ToList();
            var permutacoes = new Permutations<int>(indices);
            var filaMenorCusto = new List<Processo>();
            float? filaMenorCustoTotal = null;

            foreach (var permutacao in permutacoes)
            {
                var sequenciaExecucao = new List<Processo>();

                foreach (var indice in permutacao)
                {
                    sequenciaExecucao.Add(processos.ElementAt(indice));
                }

                var custo = CalcularCusto(sequenciaExecucao);

                if (filaMenorCustoTotal == null || filaMenorCustoTotal > custo)
                {
                    filaMenorCustoTotal = custo;
                    filaMenorCusto = sequenciaExecucao;
                }
            }

            return filaMenorCusto;
        }

        private float CalcularCusto(IEnumerable<Processo> processos)
        {
            var custo = 0f;

            for (var indiceExecucao = 0; indiceExecucao < processos.Count(); indiceExecucao++)
            {
                var custoPorMinuto = processos
                    .Skip(indiceExecucao)
                    .Sum(p => p.CustoPorHora / 60f);

                custo += processos.ElementAt(indiceExecucao).TempoExecucao * custoPorMinuto;
            }

            return custo;
        }
    }
}
