using System;
using System.Collections.Generic;

namespace PlanejamentoProducao.Api
{
    public interface IProducaoManager
    {

    }

    public class ProducaoManager : IProducaoManager
    {
        /*public ProducaoManager()
        {
            var processos = new List<Processo>
            {
                new Processo() { Identificador = "Refile Manual", TempoExecucao = 60, CustoPorHora = 30  },
                new Processo() { Identificador = "Impressão", TempoExecucao = 30, CustoPorHora = 40  },
                new Processo() { Identificador = "Acabamento", TempoExecucao = 40, CustoPorHora = 20  }
            };

            var listaMenorCustoEspera = CalcularMenorCustoEspera(processos);
            var listaMenorTempoEspera = CalcularMenorTempoEspera(processos);
        }

        private List<Processo> CalcularMenorCustoEspera(List<Processo> processos)
        {
            var indices = Enumerable.Range(0, processos.Count).ToList();
            var permutacoes = new Permutations<int>(indices);
            var retorno = new List<Processo>();
            float? custoTotalRetorno = null;

            foreach (var permutacao in permutacoes)
            {
                var sequenciaExecucao = new List<Processo>();

                foreach (var indice in permutacao)
                {
                    sequenciaExecucao.Add(processos[indice]);
                }

                var custo = CalcularCusto(sequenciaExecucao);

                if (custoTotalRetorno == null || custoTotalRetorno > custo)
                {
                    custoTotalRetorno = custo;
                    retorno = sequenciaExecucao;
                }                
            }

            return retorno;
        }

        private float CalcularCusto(List<Processo> processos)
        {
            var custo = 0f;

            for (var indiceExecucao = 0; indiceExecucao < processos.Count; indiceExecucao++)
            {
                var custoPorMinuto = processos
                    .Skip(indiceExecucao)
                    .Sum(p => p.CustoPorHora / 60f);

                custo += processos[indiceExecucao].TempoExecucao * custoPorMinuto;
            }

            return custo;
        }

        private List<Processo> CalcularMenorTempoEspera(List<Processo> processos)
        {
            return processos.OrderBy(p => p.TempoExecucao).ToList();
        }*/
    }
}
