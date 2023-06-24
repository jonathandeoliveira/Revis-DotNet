namespace Revis.Models
{
    public class SearchModel
    {
        public List<OficinaModel> oficinas { get; set; }
        public List<MecanicoModel> mecanicos { get; set; }

        // Oficinas
        public string? OficinaNome { get; set; }
        public string? OficinaCpnj { get; set; }
        public string? OficinaCep { get; set; }
        public string? OficinaEndereco { get; set; }
        public string? OficinaCidade { get; set; }
        public string? OficinaEstado { get; set; }

        // Mecanicos //
        public string? MecanicoNome { get; set; }
        public string? MecanicoCpf { get; set; }
        public string? MecanicoSexo { get; set; }
        public int? MecanicoIdade { get; set; }
        public string? MecanicoCategoriaDeManutencao { get; set; }
        public string? MecanicoResumo { get; set; }
    }
}
