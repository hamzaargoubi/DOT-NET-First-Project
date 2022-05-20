using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    CIN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.CIN);
                });

            migrationBuilder.CreateTable(
                name: "Specialites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSpecialite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avocats",
                columns: table => new
                {
                    AvocatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEmbauche = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecialiteFK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avocats", x => x.AvocatId);
                    table.ForeignKey(
                        name: "FK_Avocats_Specialites_SpecialiteFK",
                        column: x => x.SpecialiteFK,
                        principalTable: "Specialites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dossiers",
                columns: table => new
                {
                    DateDepot = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientFK = table.Column<int>(type: "int", nullable: false),
                    AvocatFK = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frais = table.Column<double>(type: "float", nullable: false),
                    Clos = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossiers", x => new { x.ClientFK, x.AvocatFK, x.DateDepot });
                    table.ForeignKey(
                        name: "FK_Dossiers_Avocats_AvocatFK",
                        column: x => x.AvocatFK,
                        principalTable: "Avocats",
                        principalColumn: "AvocatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dossiers_Clients_ClientFK",
                        column: x => x.ClientFK,
                        principalTable: "Clients",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avocats_SpecialiteFK",
                table: "Avocats",
                column: "SpecialiteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_AvocatFK",
                table: "Dossiers",
                column: "AvocatFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dossiers");

            migrationBuilder.DropTable(
                name: "Avocats");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Specialites");
        }
    }
}
