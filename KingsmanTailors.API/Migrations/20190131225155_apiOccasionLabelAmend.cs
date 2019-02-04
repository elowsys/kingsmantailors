using Microsoft.EntityFrameworkCore.Migrations;

namespace KingsmanTailors.API.Migrations
{
    public partial class apiOccasionLabelAmend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "labelName",
                table: "infOccasionLabel",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "labelName",
                table: "infOccasionLabel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
