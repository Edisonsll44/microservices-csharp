using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountPersistenceDatabase.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "account");

            migrationBuilder.CreateTable(
                name: "Cuenta",
                schema: "account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCuenta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuentaCliente",
                schema: "account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    CuentaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaCliente", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "account",
                table: "Cuenta",
                columns: new[] { "Id", "TipoCuenta" },
                values: new object[] { 1, "Ahorros" });

            migrationBuilder.InsertData(
                schema: "account",
                table: "Cuenta",
                columns: new[] { "Id", "TipoCuenta" },
                values: new object[] { 2, "Ahorros" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuenta",
                schema: "account");

            migrationBuilder.DropTable(
                name: "CuentaCliente",
                schema: "account");
        }
    }
}
