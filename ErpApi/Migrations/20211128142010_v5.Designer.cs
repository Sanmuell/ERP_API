﻿// <auto-generated />
using ErpApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ErpApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211128142010_v5")]
    partial class v5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ErpApi.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("ErpApi.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("ErpApi.Models.Fornecedor", b =>
                {
                    b.HasOne("ErpApi.Models.Empresa", "Empresa")
                        .WithMany("Fornecedor")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("ErpApi.Models.Empresa", b =>
                {
                    b.Navigation("Fornecedor");
                });
#pragma warning restore 612, 618
        }
    }
}
