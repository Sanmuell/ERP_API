using ErpApi.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpApi.Validator
{
    public class EmpresaValidator  : AbstractValidator<Empresa>
    {
        public EmpresaValidator()
        {
            RuleFor(x => x.NomeFantasia).NotNull().NotEmpty();
            RuleFor(x => x.Uf).NotNull().NotEmpty();
            RuleFor(x => x.Cnpj).NotNull().NotEmpty().MinimumLength(14).MaximumLength(14);

        }

    }
}
