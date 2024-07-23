using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infra.Data.Migrations
{
    public partial class Incluindo_empesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    razao_social = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    unidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Empresa",
                columns: new[] { "id", "cnpj", "nome", "razao_social", "unidade" },
                values: new object[] { 1, "48063859000176", "system", "empresa system", "GO" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "id",
                keyValue: 1,
                column: "data_nascimento",
                value: new DateTime(2024, 7, 22, 23, 27, 18, 45, DateTimeKind.Local).AddTicks(1223));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "id",
                keyValue: 1,
                column: "data_nascimento",
                value: new DateTime(2024, 7, 22, 23, 18, 16, 522, DateTimeKind.Local).AddTicks(673));
        }
    }
}
