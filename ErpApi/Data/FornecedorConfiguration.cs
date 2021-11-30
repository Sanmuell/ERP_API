using ErpApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpApi.Data
{
    public class FornecedorConfiguration
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.Property(p => p.tipoPessoa).HasConversion(
                p => p.ToString(),
                p => (TipoPessoa)Enum.Parse(typeof(TipoPessoa), p)
                );

        }

    }
}
