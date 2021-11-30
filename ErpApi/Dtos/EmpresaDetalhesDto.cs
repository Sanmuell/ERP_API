using ErpApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpApi.Dtos
{
    public class EmpresaDetalhesDto
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }

        public string Uf { get; set; }

        public string Cnpj { get; set; }


        public string Fornecedores { get; set; }

       
    }
}
