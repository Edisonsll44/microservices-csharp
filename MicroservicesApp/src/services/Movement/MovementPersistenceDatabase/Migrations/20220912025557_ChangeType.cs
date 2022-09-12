using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovementPersistenceDatabase.Migrations
{
    public partial class ChangeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "movement",
                table: "Movimientos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                schema: "movement",
                table: "Movimientos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Tipo",
                schema: "movement",
                table: "Movimientos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                schema: "movement",
                table: "Movimientos",
                columns: new[] { "Id", "CuentaId", "Saldo", "Fechamovimiento", "TipoMovimiento", "Tipo" },
                values: new object[] { 1, 1, 2000m, new DateTime(2022, 9, 8, 15, 12, 19, 259, DateTimeKind.Local).AddTicks(4903), "Retiro de 575", 0m });
        }
    }
}
