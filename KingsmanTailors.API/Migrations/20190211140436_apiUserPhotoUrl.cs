using Microsoft.EntityFrameworkCore.Migrations;

namespace KingsmanTailors.API.Migrations
{
    public partial class apiUserPhotoUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "photoUrl",
                table: "datUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "publicId",
                table: "datSuitPhoto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photoUrl",
                table: "datUser");

            migrationBuilder.DropColumn(
                name: "publicId",
                table: "datSuitPhoto");
        }
    }
}
