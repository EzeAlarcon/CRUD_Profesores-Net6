using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud_Profesores.Migrations
{
    // Clase de migración llamada "Profesores"
    public partial class Profesores : Migration
    {
        // Método Up: Define las operaciones al aplicar la migración
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Crea una nueva tabla "Profesores" con las siguientes columnas
            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    // Id: Identificador único, clave primaria con autoincremento
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),

                    // Name: Nombre del profesor, cadena de hasta 50 caracteres, no nula
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),

                    // Subject: Materia que enseña el profesor, cadena de hasta 500 caracteres, no nula
                    Subject = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),

                    // Grade: Grado del profesor, valor decimal de 18 dígitos con 2 decimales, no nulo
                    Grade = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                // Restricciones: Define la clave primaria (PK_Profesores) en la columna Id
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Id);
                });

            // Crea un índice único (IX_Profesores_Name) en la columna Name para evitar duplicados
            migrationBuilder.CreateIndex(
                name: "IX_Profesores_Name",
                table: "Profesores",
                column: "Name",
                unique: true);
        }

        // Método Down: Define las operaciones al revertir la migración
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Elimina la tabla "Profesores" si la migración se revierte
            migrationBuilder.DropTable(
                name: "Profesores");
        }
    }
}
