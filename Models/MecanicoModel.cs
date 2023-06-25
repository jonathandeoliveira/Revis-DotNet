namespace Revis.Models
{
    public class MecanicoModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string sexo { get; set; }
        public int idade { get; set; }
        public string categoriaDeManutencao { get; set; }
        public string resumo { get; set; }
        public int oficinaId { get; set; }
        public virtual OficinaModel oficina { get; set; }
    }


}
