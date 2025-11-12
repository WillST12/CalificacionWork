using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calificacionesp2.Migrations
{
    /// <inheritdoc />
    public partial class FixProfesorMateriav2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Materias_IdMateria",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Profesores_IdProfesor",
                table: "Clases");

            migrationBuilder.DropIndex(
                name: "IX_Clases_IdMateria",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "IdMateria",
                table: "Clases");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProfesorMaterias",
                newName: "IdProfesorMateria");

            migrationBuilder.RenameColumn(
                name: "IdProfesor",
                table: "Clases",
                newName: "IdProfesorMateria");

            migrationBuilder.RenameIndex(
                name: "IX_Clases_IdProfesor",
                table: "Clases",
                newName: "IX_Clases_IdProfesorMateria");

            migrationBuilder.AddColumn<int>(
                name: "ProfesorIdProfesor",
                table: "Clases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clases_ProfesorIdProfesor",
                table: "Clases",
                column: "ProfesorIdProfesor");

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_ProfesorMaterias_IdProfesorMateria",
                table: "Clases",
                column: "IdProfesorMateria",
                principalTable: "ProfesorMaterias",
                principalColumn: "IdProfesorMateria",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Profesores_ProfesorIdProfesor",
                table: "Clases",
                column: "ProfesorIdProfesor",
                principalTable: "Profesores",
                principalColumn: "IdProfesor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clases_ProfesorMaterias_IdProfesorMateria",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Profesores_ProfesorIdProfesor",
                table: "Clases");

            migrationBuilder.DropIndex(
                name: "IX_Clases_ProfesorIdProfesor",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "ProfesorIdProfesor",
                table: "Clases");

            migrationBuilder.RenameColumn(
                name: "IdProfesorMateria",
                table: "ProfesorMaterias",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdProfesorMateria",
                table: "Clases",
                newName: "IdProfesor");

            migrationBuilder.RenameIndex(
                name: "IX_Clases_IdProfesorMateria",
                table: "Clases",
                newName: "IX_Clases_IdProfesor");

            migrationBuilder.AddColumn<int>(
                name: "IdMateria",
                table: "Clases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clases_IdMateria",
                table: "Clases",
                column: "IdMateria");

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Materias_IdMateria",
                table: "Clases",
                column: "IdMateria",
                principalTable: "Materias",
                principalColumn: "IdMateria",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Profesores_IdProfesor",
                table: "Clases",
                column: "IdProfesor",
                principalTable: "Profesores",
                principalColumn: "IdProfesor",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
