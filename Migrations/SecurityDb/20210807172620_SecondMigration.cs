using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiREST.Migrations.SecurityDb
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fk_Usuario",
                table: "Alumno",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_Fk_Usuario",
                table: "Alumno",
                column: "Fk_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_AspNetUsers_Fk_Usuario",
                table: "Alumno",
                column: "Fk_Usuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_AspNetUsers_Fk_Usuario",
                table: "Alumno");

            migrationBuilder.DropIndex(
                name: "IX_Alumno_Fk_Usuario",
                table: "Alumno");

            migrationBuilder.DropColumn(
                name: "Fk_Usuario",
                table: "Alumno");
        }
    }
}
