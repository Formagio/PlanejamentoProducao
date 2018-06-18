using PlanejamentoProducao.Api.Models;
using PlanejamentoProducao.Api.ProcessadorFila;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanejamentoProducao.Api
{
    public interface IGerenciadorFila
    {
        void IncluirProcesso(Processo processo);
        IEnumerable<Processo> ProcessarFila(IProcessadorFila processadorFila);
    }

    public class GerenciadorFila : IGerenciadorFila
    {
        private List<Processo> _processos;
        
        public GerenciadorFila()
        {
            _processos = new List<Processo>();
        }

        public void IncluirProcesso(Processo processo)
        {            
            if (_processos.Any(p => 
                    p.Identificador.Equals(processo.Identificador, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new ArgumentException($"Identificador '{processo.Identificador}' já existe!");
            }

            _processos.Add(processo);
        }

        public IEnumerable<Processo> ProcessarFila(IProcessadorFila _processadorFila)
        {
            return _processadorFila.ProcessarFila(_processos).ToList();
        }
    }
}
