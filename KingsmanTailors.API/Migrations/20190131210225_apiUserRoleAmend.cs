using Microsoft.EntityFrameworkCore.Migrations;

namespace KingsmanTailors.API.Migrations
{
    public partial class apiUserRoleAmend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "roleAbbrev",
                table: "datRole",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roleAbbrev",
                table: "datRole");
        }
    }
}
