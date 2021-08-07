using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiREST.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condiciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condiciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosCiviles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosCiviles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nacionalidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Dia = table.Column<int>(type: "int", nullable: false),
                    Fk_Horario = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modulos_Dias_Fk_Dia",
                        column: x => x.Fk_Dia,
                        principalTable: "Dias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Modulos_Horarios_Fk_Horario",
                        column: x => x.Fk_Horario,
                        principalTable: "Horarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificadoSaludId = table.Column<int>(type: "int", nullable: false),
                    CertificadoSecundariaId = table.Column<int>(type: "int", nullable: false),
                    FotoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_TipoDoc = table.Column<int>(type: "int", nullable: false),
                    NroDocumento = table.Column<double>(type: "float", nullable: false),
                    Fk_Genero = table.Column<int>(type: "int", nullable: false),
                    Fk_Localidad = table.Column<int>(type: "int", nullable: false),
                    Fk_Nacionalidad = table.Column<int>(type: "int", nullable: false),
                    Fk_EstadoCivil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alumno_EstadosCiviles_Fk_EstadoCivil",
                        column: x => x.Fk_EstadoCivil,
                        principalTable: "EstadosCiviles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumno_Generos_Fk_Genero",
                        column: x => x.Fk_Genero,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumno_Localidades_Fk_Localidad",
                        column: x => x.Fk_Localidad,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumno_Nacionalidades_Fk_Nacionalidad",
                        column: x => x.Fk_Nacionalidad,
                        principalTable: "Nacionalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumno_TiposDocs_Fk_TipoDoc",
                        column: x => x.Fk_TipoDoc,
                        principalTable: "TiposDocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InscripcionCarrera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Carrera = table.Column<int>(type: "int", nullable: false),
                    AlumnosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscripcionCarrera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InscripcionCarrera_Alumno_AlumnosId",
                        column: x => x.AlumnosId,
                        principalTable: "Alumno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InscripcionCarrera_Carrera_Fk_Carrera",
                        column: x => x.Fk_Carrera,
                        principalTable: "Carrera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_Fk_EstadoCivil",
                table: "Alumno",
                column: "Fk_EstadoCivil");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_Fk_Genero",
                table: "Alumno",
                column: "Fk_Genero");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_Fk_Localidad",
                table: "Alumno",
                column: "Fk_Localidad");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_Fk_Nacionalidad",
                table: "Alumno",
                column: "Fk_Nacionalidad");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_Fk_TipoDoc",
                table: "Alumno",
                column: "Fk_TipoDoc");

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionCarrera_AlumnosId",
                table: "InscripcionCarrera",
                column: "AlumnosId");

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionCarrera_Fk_Carrera",
                table: "InscripcionCarrera",
                column: "Fk_Carrera");

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_Fk_Dia",
                table: "Modulos",
                column: "Fk_Dia");

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_Fk_Horario",
                table: "Modulos",
                column: "Fk_Horario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "Condiciones");

            migrationBuilder.DropTable(
                name: "InscripcionCarrera");

            migrationBuilder.DropTable(
                name: "Modulos");

            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "Carrera");

            migrationBuilder.DropTable(
                name: "Dias");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "EstadosCiviles");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Nacionalidades");

            migrationBuilder.DropTable(
                name: "TiposDocs");
        }
    }
}
