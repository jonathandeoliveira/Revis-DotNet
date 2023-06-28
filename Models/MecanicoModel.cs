using System.ComponentModel.DataAnnotations;

namespace Revis.Models
{
    public class MecanicoModel
    {
        public int id { get; set; }
        public string nome { get; set; }

        [RegularExpression(@"\d{3}\.\d{3}\.\d{3}-\d{2}", ErrorMessage = "O CPF está em um formato inválido.")]
        public string cpf { get; set; }
        public string sexo { get; set; }
        public int idade { get; set; }
        public string categoriaDeManutencao { get; set; }
        public string resumo { get; set; }
        public int oficinaId { get; set; }
        public virtual OficinaModel oficina { get; set; }
    }


}
