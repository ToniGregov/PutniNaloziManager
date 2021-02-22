using Microsoft.EntityFrameworkCore.Migrations;

namespace PutniNaloziManager.Migrations
{
    public partial class UpdateRelacijeNalogaIPutnika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PutniciID",
                table: "PutniNalozi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PutniciID",
                table: "PutniNalozi",
                type: "TEXT",
                nullable: true);
        }
    }
}
