using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientPersistenceDatabase.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "client");

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contrasenia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "client",
                table: "Cliente",
                columns: new[] { "Id", "Direccion", "Edad", "Genero", "Identificacion", "Nombre", "Contrasenia", "Estado", "Telefono" },
                values: new object[] { 1, "Otavalo sn y principal ", 27, "Masculino", "1802245263", "Jose Lema", "1234", true, "098254785 " });

            migrationBuilder.InsertData(
                schema: "client",
                table: "Cliente",
                columns: new[] { "Id", "Direccion", "Edad", "Genero", "Identificacion", "Nombre", "Contrasenia", "Estado", "Telefono" },
                values: new object[] { 2, "Amazonas y  NNUU", 50, "Femenino", "1804568765", "Marianela Montalvo", "5678", true, "097548965  " });

            migrationBuilder.InsertData(
                schema: "client",
                table: "Cliente",
                columns: new[] { "Id", "Direccion", "Edad", "Genero", "Identificacion", "Nombre", "Contrasenia", "Estado", "Telefono" },
                values: new object[] { 3, "13 junio y Equinoccial", 37, "Masculino", "180224522001", "Juan Osorio", "4322", true, "098874587 " });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Id",
                schema: "client",
                table: "Cliente",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "client");
        }
    }
}
