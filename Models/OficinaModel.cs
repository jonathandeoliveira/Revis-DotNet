using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Revis.Models
{
    public class OficinaModel
    {
        public int id { get; set; }
        public string nome { get; set; }

        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$", ErrorMessage = "O CNPJ está em um formato inválido.")]
        public string cpnj { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }

        public virtual ICollection<MecanicoModel> mecanicos { get; set; }
    }

}
