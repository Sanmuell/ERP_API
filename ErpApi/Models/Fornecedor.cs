using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ErpApi.Models
{


	public class Fornecedor
	{ 

	[Key]
	public int Id { get; set; }

        public string Nome { get; set; }


		//Relacionamento 
		[ForeignKey("Empresa")]
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

    }}
	
	