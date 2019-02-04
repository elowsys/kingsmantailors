using Microsoft.EntityFrameworkCore.Migrations;

namespace KingsmanTailors.API.Migrations
{
    public partial class apiUserAmend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "datUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_datUser",
                table: "datUser",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_datUser",
                table: "datUser");

            migrationBuilder.RenameTable(
                name: "datUser",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
