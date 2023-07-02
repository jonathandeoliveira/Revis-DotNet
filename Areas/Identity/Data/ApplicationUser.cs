using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Revis.Models;

namespace Revis.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Nome { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Sobrenome { get; set; }

        [PersonalData]
        [RegularExpression(@"\d{3}\.\d{3}\.\d{3}-\d{2}", ErrorMessage = "O CPF está em um formato inválido.")]
        [Column(TypeName = "nvarchar(100)")]
        public string CPF { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Telefone { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string EnderecoCompleto { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Estado { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Cidade { get; set; }

        [PersonalData]
        [Column(TypeName = "int")]
        public int orderId { get; set; }
    }
}
