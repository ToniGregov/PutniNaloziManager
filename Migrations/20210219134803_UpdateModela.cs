using Microsoft.EntityFrameworkCore.Migrations;

namespace PutniNaloziManager.Migrations
{
    public partial class UpdateModela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PutniciID",
                table: "PutniNalozi",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PutniciID",
                table: "PutniNalozi");
        }
    }
}
