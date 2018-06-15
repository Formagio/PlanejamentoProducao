using Combinatorics.Collections;
using PlanejamentoProducao.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanejamentoProducao.Api
{
    public interface IProducaoManager
    {
        void AdicionarProcesso(Processo processo);
    }

    public class ProducaoManager : IProducaoManager
    {
        private List<Processo> _processosNaFila;
        public IEnumerable<Processo> FilaMenorTempoEspera { get; private set; }
        public IEnumerable<Processo> FilaMenorCustoEspera { get; private set; }

        public ProducaoManager()
        {
            _processosNaFila = new List<Processo>();
            FilaMenorTempoEspera = new List<Processo>();
            FilaMenorCustoEspera = new List<Processo>();
        }

        public void AdicionarProcesso(Processo processo)
        {            
            if (_processosNaFila.Any(p => 
                    p.Identificador.Equals(processo.Identificador, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new ArgumentException($"Identificador {processo.Identificador} já existente!");
            }

            _processosNaFila.Add(processo);
            FilaMenorTempoEspera = CalcularMenorTempoEspera(_processosNaFila);
            FilaMenorCustoEspera = CalcularMenorCustoEspera(_processosNaFila);
        }

        private IEnumerable<Processo> CalcularMenorTempoEspera(IEnumerable<Processo> processos)
        {
            return processos.OrderBy(p => p.TempoExecucao).ToList();
        }

        private IEnumerable<Processo> CalcularMenorCustoEspera(IEnumerable<Processo> processos)
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
