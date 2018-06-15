namespace PlanejamentoProducao.Api.Models
{
    public class Processo
    {
        public string Identificador { get; set; }
        public uint TempoExecucao { get; set; }
        public uint CustoPorHora { get; set; }
    }
}
