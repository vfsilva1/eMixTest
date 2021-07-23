using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CEPCounsult.Models
{
    public class CEP
    {
        public int CepID { get; set; }

        [Column(TypeName = "char(9)")]
        public string Cep { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Logradouro { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Complemento { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string  Bairro { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Localidade { get; set; }

        [Column(TypeName = "char(2)")]
        public string UF { get; set; }

        [Column(TypeName = "bigint")]
        public int Unidade { get; set; }

        [Column(TypeName = "int")]
        public int IBGE { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string GIA { get; set; }
    }
}
