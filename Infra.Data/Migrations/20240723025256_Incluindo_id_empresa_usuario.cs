using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class Incluindo_id_empresa_usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_empresa",
                table: "Usuarios",
                type: "integer",
                maxLength: 10,
                nullable: false,
                defaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "data_nascimento", "id_empresa" },
                values: new object[] { new DateTime(2024, 7, 22, 23, 52, 56, 130, DateTimeKind.Local).AddTicks(3714), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_empresa",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "id",
                keyValue: 1,
                column: "data_nascimento",
                value: new DateTime(2024, 7, 22, 23, 46, 25, 748, DateTimeKind.Local).AddTicks(305));
        }
    }
}
