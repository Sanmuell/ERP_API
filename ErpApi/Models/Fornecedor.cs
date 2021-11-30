using ErpApi.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ErpApi.Models
{


	public class Fornecedor : IValidatableObject
    { 

	[Key]
	public int Id { get; set; }

        public string Nome { get; set; }

        public ETipoPessoa TipoPessoa { get; set; }

        public string Cpf { get; set; }

		public string Rg { get; set; }

		[Display ]
		public string Cnpj { get; set; }

        public DateTime DataeHoraCadastro { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime DataNascimento { get; set; }
		

        public string Telefone { get; set; }

        //Relacionamento 
        [ForeignKey("Empresa")]
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
			if (TipoPessoa != ETipoPessoa.JURIDICA)
			{

				//Valida o Nome
				if (String.IsNullOrWhiteSpace(Nome))
					yield return new ValidationResult("O campo NOME deve ser informado para pessoa jurídica");

				if (String.IsNullOrWhiteSpace(Cnpj))
					yield return new ValidationResult("O campo Cnpj fantasia deve ser informado para pessoa jurídica");
			}
			else 

			if (String.IsNullOrWhiteSpace(Rg))
				yield return new ValidationResult("O campo RG deve ser informado para pessoa Fisica");


			int varAno = DataNascimento.Year;
			int idade =   DateTime.Now.Year - varAno;

			if (idade < 18 )
				yield return new ValidationResult("Cadastro não permitido para pessoa menor de idade");


		}
	}
}
	
	