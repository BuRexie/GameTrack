using Microsoft.EntityFrameworkCore.Migrations;

namespace GameTrack.Migrations
{
    public partial class RemovedProgressField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Progress",
                table: "Players");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Progress",
                table: "Players",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
