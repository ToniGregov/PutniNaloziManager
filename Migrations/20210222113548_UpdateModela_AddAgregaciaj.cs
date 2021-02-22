using Microsoft.EntityFrameworkCore.Migrations;

namespace PutniNaloziManager.Migrations
{
    public partial class UpdateModela_AddAgregaciaj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PutniNalogPutnik");

            migrationBuilder.DropColumn(
                name: "NaloziID",
                table: "Putnici");

            migrationBuilder.CreateTable(
                name: "PutniNaloziPutnici",
                columns: table => new
                {
                    PutniNalogId = table.Column<int>(type: "INTEGER", nullable: false),
                    PutnikId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PutniNaloziPutnici", x => new { x.PutnikId, x.PutniNalogId });
                    table.ForeignKey(
                        name: "FK_PutniNaloziPutnici_Putnici_PutnikId",
                        column: x => x.PutnikId,
                        principalTable: "Putnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PutniNaloziPutnici_PutniNalozi_PutniNalogId",
                        column: x => x.PutniNalogId,
                        principalTable: "PutniNalozi",
                        principalColumn: "RedniBrojNaloga",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PutniNaloziPutnici_PutniNalogId",
                table: "PutniNaloziPutnici",
                column: "PutniNalogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PutniNaloziPutnici");

            migrationBuilder.AddColumn<int>(
                name: "NaloziID",
                table: "Putnici",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
