using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infra.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    cargo = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    telefone = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    perfil_usuario = table.Column<string>(type: "text", nullable: false),
                    matricula = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    nome_empresa = table.Column<string>(type: "text", nullable: true),
                    permissao = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });           

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "id", "cargo", "cpf", "data_nascimento", "email", "matricula", "nome", "nome_empresa", "password", "perfil_usuario", "permissao", "telefone" },
                values: new object[] { 1, "suporte", "11111111111", new DateTime(2024, 7, 8, 10, 13, 34, 978, DateTimeKind.Local).AddTicks(5787), "system@gmail.com", "000000", "system", "system", "$2a$10$e/IZDBCPryoa6XMwowkItuVWAeZmYOH1RiinVrcHVTm560uGIaUa2", "https://static.vecteezy.com/ti/vetor-gratis/p3/2387693-icone-do-perfil-do-usuario-vetor.jpg", "admin", "99999999999" });
                        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
