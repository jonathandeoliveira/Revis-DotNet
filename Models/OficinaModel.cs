namespace Revis.Models
{
    public class OficinaModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpnj { get; set; }
        public string endereco { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }

        public virtual ICollection<MecanicoModel> mecanicos { get; set; }
    }
}
