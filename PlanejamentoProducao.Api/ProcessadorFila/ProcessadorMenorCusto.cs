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
            var tempoTranscorrido = 0;

            for (var indiceProcesso = 0; indiceProcesso < processos.Count(); indiceProcesso++)
            {
                var somaCustoPorHora = processos
                    .Skip(indiceProcesso)
                    .Sum(p => p.CustoPorHora);

                for (int minuto = 0; minuto < processos.ElementAt(indiceProcesso).TempoExecucao; minuto++)
                {
                    tempoTranscorrido++;

                    // O custo da tarefa deve ser cobrado a cada hora transcorrida (60 minutos)
                    if (tempoTranscorrido == 60)
                    {
                        custo += processos.ElementAt(indiceProcesso).TempoExecucao * somaCustoPorHora;
                        tempoTranscorrido = 0;
                    }
                }
            }

            /* 
             * Esta é outra forma que encontrei para calcular o custo.
             * A cada minuto transcorrido ela soma o custo de todas as tarefas pendentes.
            for (var indiceProcesso = 0; indiceProcesso < processos.Count(); indiceProcesso++)
            {
                var custoPorMinuto = processos
                    .Skip(indiceProcesso)
                    .Sum(p => p.CustoPorHora / 60f);

                custo += processos.ElementAt(indiceProcesso).TempoExecucao * custoPorMinuto;
            }*/

            return custo;
        }
    }
}
