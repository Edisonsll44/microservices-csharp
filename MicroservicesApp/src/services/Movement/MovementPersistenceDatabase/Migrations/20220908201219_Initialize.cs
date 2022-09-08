using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovementPersistenceDatabase.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "movement");

            migrationBuilder.CreateTable(
                name: "Movimientos",
                schema: "movement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fechamovimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoMovimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CuentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "movement",
                table: "Movimientos",
                columns: new[] { "Id", "CuentaId", "Saldo", "Fechamovimiento", "TipoMovimiento", "Tipo" },
                values: new object[] { 1, 1, 2000m, new DateTime(2022, 9, 8, 15, 12, 19, 259, DateTimeKind.Local).AddTicks(4903), "Retiro de 575", 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos",
                schema: "movement");
        }
    }
}
