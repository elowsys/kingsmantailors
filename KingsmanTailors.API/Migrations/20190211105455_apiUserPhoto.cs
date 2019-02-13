using Microsoft.EntityFrameworkCore.Migrations;

namespace KingsmanTailors.API.Migrations
{
    public partial class apiUserPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "publicId",
                table: "datUser",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "publicId",
                table: "datUser");
        }
    }
}
