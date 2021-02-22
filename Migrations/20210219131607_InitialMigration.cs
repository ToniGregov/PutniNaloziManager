using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PutniNaloziManager.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automobili",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Marka = table.Column<string>(type: "TEXT", nullable: true),
                    Naziv = table.Column<string>(type: "TEXT", nullable: true),
                    RegistracijskaOznaka = table.Column<string>(type: "TEXT", nullable: true),
                    Kilometraza = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobili", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Putnici",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Ime = table.Column<string>(type: "TEXT", nullable: true),
                    Prezime = table.Column<string>(type: "TEXT", nullable: true),
                    NaloziID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Putnici", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PutniNalozi",
                columns: table => new
                {
                    RedniBrojNaloga = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Polazak = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Povratak = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RazlogPutovanja = table.Column<string>(type: "TEXT", nullable: false),
                    Polaziste = table.Column<string>(type: "TEXT", nullable: false),
                    Odrediste = table.Column<string>(type: "TEXT", nullable: false),
                    Prijevoz = table.Column<string>(type: "TEXT", nullable: false),
                    AutomobilID = table.Column<string>(type: "TEXT", nullable: true),
                    Komentar = table.Column<string>(type: "TEXT", nullable: true),
                    EmailZaOdobrenje = table.Column<string>(type: "TEXT", nullable: false),
                    PocetnaKilometraza = table.Column<decimal>(type: "TEXT", nullable: false),
                    ZavrsnaKilometraza = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsLocked = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PutniNalozi", x => x.RedniBrojNaloga);
                    table.ForeignKey(
                        name: "FK_PutniNalozi_Automobili_AutomobilID",
                        column: x => x.AutomobilID,
                        principalTable: "Automobili",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PutniNalogPutnik",
                columns: table => new
                {
                    NaloziRedniBrojNaloga = table.Column<int>(type: "INTEGER", nullable: false),
                    PutniciID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PutniNalogPutnik", x => new { x.NaloziRedniBrojNaloga, x.PutniciID });
                    table.ForeignKey(
                        name: "FK_PutniNalogPutnik_Putnici_PutniciID",
                        column: x => x.PutniciID,
                        principalTable: "Putnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PutniNalogPutnik_PutniNalozi_NaloziRedniBrojNaloga",
                        column: x => x.NaloziRedniBrojNaloga,
                        principalTable: "PutniNalozi",
                        principalColumn: "RedniBrojNaloga",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PutniNalogPutnik_PutniciID",
                table: "PutniNalogPutnik",
                column: "PutniciID");

            migrationBuilder.CreateIndex(
                name: "IX_PutniNalozi_AutomobilID",
                table: "PutniNalozi",
                column: "AutomobilID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PutniNalogPutnik");

            migrationBuilder.DropTable(
                name: "Putnici");

            migrationBuilder.DropTable(
                name: "PutniNalozi");

            migrationBuilder.DropTable(
                name: "Automobili");
        }
    }
}
