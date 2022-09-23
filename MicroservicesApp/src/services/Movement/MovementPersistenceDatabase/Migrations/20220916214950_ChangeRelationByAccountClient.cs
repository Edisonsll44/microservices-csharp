using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovementPersistenceDatabase.Migrations
{
    public partial class ChangeRelationByAccountClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                schema: "movement",
                table: "Movimientos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                schema: "movement",
                table: "Movimientos");
        }
    }
}
