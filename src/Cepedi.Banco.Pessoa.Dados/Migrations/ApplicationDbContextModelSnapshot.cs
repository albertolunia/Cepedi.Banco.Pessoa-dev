﻿// <auto-generated />
using System;
using Cepedi.Banco.Pessoa.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cepedi.Banco.Pessoa.Dados.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.17");

            modelBuilder.Entity("Cepedi.Banco.Pessoa.Dominio.Entidades.EnderecoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoa");

                    b.ToTable("Endereco", (string)null);
                });

            modelBuilder.Entity("Cepedi.Banco.Pessoa.Dominio.Entidades.PessoaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("EstadoCivil")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pessoa", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "12345678901",
                            DataNascimento = new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -2, 0, 0, 0)),
                            Email = "teste",
                            EstadoCivil = "Solteiro",
                            Genero = "M",
                            Nacionalidade = "Brasileiro",
                            Nome = "João da Silva",
                            Telefone = "11999999999"
                        });
                });

            modelBuilder.Entity("Cepedi.Banco.Pessoa.Dominio.Entidades.EnderecoEntity", b =>
                {
                    b.HasOne("Cepedi.Banco.Pessoa.Dominio.Entidades.PessoaEntity", "Pessoa")
                        .WithMany("Enderecos")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Cepedi.Banco.Pessoa.Dominio.Entidades.PessoaEntity", b =>
                {
                    b.Navigation("Enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
