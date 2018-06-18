using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlanejamentoProducao.Web.Areas.Api.Models
{
    public class GerenciadorFilaViewModel
    {
        [JsonProperty(PropertyName = "menor_tempo_espera")]
        public IEnumerable<string> FilaMenorTempoEspera { get; set; }

        [JsonProperty(PropertyName = "menor_custo_espera")]
        public IEnumerable<string> FilaMenorCustoEspera { get; set; }
    }
}
