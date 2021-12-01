using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpApi.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set;}

        public string NomeFantasia { get; set; }

        public string Uf { get; set; }

        public string Cnpj { get; set; }

        public virtual IEnumerable<Fornecedor> Fornecedores { get; } 
    }
}
