using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepedi.Banco.Pessoa.Dados.Migrations
{
    /// <inheritdoc />
    public partial class Pessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pessoa",
                columns: new[] { "Id", "Cpf", "DataNascimento", "Email", "EstadoCivil", "Genero", "Nacionalidade", "Nome", "Telefone" },
                values: new object[] { 1, "12345678901", new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -2, 0, 0, 0)), "teste", "Solteiro", "M", "Brasileiro", "João da Silva", "11999999999" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
