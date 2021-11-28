using ErpApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpApi.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }

      




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=Erp;Data Source=DESKTOP-2L8L09R");
        }



    }
}
