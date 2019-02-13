using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KingsmanTailors.API.Migrations
{
    public partial class apiSuitPhotoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "suitImg",
                table: "datSuit");

            migrationBuilder.CreateTable(
                name: "datSuitPhoto",
                columns: table => new
                {
                    photoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    suitId = table.Column<int>(nullable: false),
                    photoDesc = table.Column<string>(nullable: true),
                    photoUrl = table.Column<string>(nullable: true),
                    isDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datSuitPhoto", x => x.photoId);
                    table.ForeignKey(
                        name: "FK_datSuitPhoto_datSuit_suitId",
                        column: x => x.suitId,
                        principalTable: "datSuit",
                        principalColumn: "suitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_datSuitPhoto_suitId",
                table: "datSuitPhoto",
                column: "suitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "datSuitPhoto");

            migrationBuilder.AddColumn<string>(
                name: "suitImg",
                table: "datSuit",
                nullable: true);
        }
    }
}
