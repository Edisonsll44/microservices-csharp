using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountPersistenceDatabase.Migrations
{
    public partial class ChangeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CuentaCliente_CuentaId",
                schema: "account",
                table: "CuentaCliente",
                column: "CuentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaCliente_Cuenta_CuentaId",
                schema: "account",
                table: "CuentaCliente",
                column: "CuentaId",
                principalSchema: "account",
                principalTable: "Cuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCliente_Cuenta_CuentaId",
                schema: "account",
                table: "CuentaCliente");

            migrationBuilder.DropIndex(
                name: "IX_CuentaCliente_CuentaId",
                schema: "account",
                table: "CuentaCliente");
        }
    }
}
