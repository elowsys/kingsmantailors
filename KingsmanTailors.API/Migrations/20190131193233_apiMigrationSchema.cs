using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KingsmanTailors.API.Migrations
{
    public partial class apiMigrationSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "datAppointment",
                columns: table => new
                {
                    appointmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appointmentDate = table.Column<DateTime>(nullable: false),
                    custName = table.Column<string>(nullable: false),
                    custPhone = table.Column<string>(nullable: true),
                    custEmail = table.Column<string>(nullable: true),
                    isConfirmed = table.Column<bool>(nullable: false),
                    salesRep = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datAppointment", x => x.appointmentId);
                });

            migrationBuilder.CreateTable(
                name: "datRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    roleId = table.Column<string>(nullable: true),
                    roleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "datUserRole",
                columns: table => new
                {
                    userRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<string>(nullable: true),
                    roleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datUserRole", x => x.userRoleId);
                });

            migrationBuilder.CreateTable(
                name: "infFabric",
                columns: table => new
                {
                    fabricId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fabricName = table.Column<string>(nullable: true),
                    fabricDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infFabric", x => x.fabricId);
                });

            migrationBuilder.CreateTable(
                name: "infFrontStyle",
                columns: table => new
                {
                    frontId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    frontName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infFrontStyle", x => x.frontId);
                });

            migrationBuilder.CreateTable(
                name: "infLapelStyle",
                columns: table => new
                {
                    lapelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    lapelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infLapelStyle", x => x.lapelId);
                });

            migrationBuilder.CreateTable(
                name: "infOccasionFit",
                columns: table => new
                {
                    fitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fitName = table.Column<string>(nullable: true),
                    fitDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infOccasionFit", x => x.fitId);
                });

            migrationBuilder.CreateTable(
                name: "infOccasionLabel",
                columns: table => new
                {
                    labelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    labelName = table.Column<int>(nullable: false),
                    labelDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infOccasionLabel", x => x.labelId);
                });

            migrationBuilder.CreateTable(
                name: "infOccasionStyle",
                columns: table => new
                {
                    styleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    styleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infOccasionStyle", x => x.styleId);
                });

            migrationBuilder.CreateTable(
                name: "infSalesTag",
                columns: table => new
                {
                    tagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tagName = table.Column<string>(nullable: true),
                    applyAdjust = table.Column<bool>(nullable: false),
                    priceAdjust = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infSalesTag", x => x.tagId);
                });

            migrationBuilder.CreateTable(
                name: "infSuitSize",
                columns: table => new
                {
                    sizeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    sizeName = table.Column<string>(nullable: true),
                    adjustIndex = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infSuitSize", x => x.sizeId);
                });

            migrationBuilder.CreateTable(
                name: "infSuitType",
                columns: table => new
                {
                    suitTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    typeName = table.Column<string>(nullable: true),
                    typeDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infSuitType", x => x.suitTypeId);
                });

            migrationBuilder.CreateTable(
                name: "infVentStyle",
                columns: table => new
                {
                    ventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ventName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infVentStyle", x => x.ventId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(nullable: true),
                    passwordHash = table.Column<byte[]>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    accountConfirmed = table.Column<bool>(nullable: false),
                    displayName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    lockoutEnabled = table.Column<bool>(nullable: false),
                    lockOutEnd = table.Column<DateTime>(nullable: false),
                    accessFailedCount = table.Column<int>(nullable: false),
                    phoneNumber = table.Column<string>(nullable: true),
                    securityStamp = table.Column<byte[]>(nullable: true),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "infOccasionType",
                columns: table => new
                {
                    typeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    labelId = table.Column<int>(nullable: false),
                    colorName = table.Column<string>(nullable: true),
                    colorValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infOccasionType", x => x.typeId);
                    table.ForeignKey(
                        name: "FK_infOccasionType_infOccasionLabel_labelId",
                        column: x => x.labelId,
                        principalTable: "infOccasionLabel",
                        principalColumn: "labelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "datSuit",
                columns: table => new
                {
                    suitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    suitDesc = table.Column<string>(nullable: true),
                    suitImg = table.Column<string>(nullable: true),
                    suitTypeId = table.Column<int>(nullable: false),
                    typeId = table.Column<int>(nullable: false),
                    fitId = table.Column<int>(nullable: false),
                    styleId = table.Column<int>(nullable: false),
                    lapelId = table.Column<int>(nullable: false),
                    frontId = table.Column<int>(nullable: false),
                    ventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datSuit", x => x.suitId);
                    table.ForeignKey(
                        name: "FK_datSuit_infOccasionFit_fitId",
                        column: x => x.fitId,
                        principalTable: "infOccasionFit",
                        principalColumn: "fitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_datSuit_infFrontStyle_frontId",
                        column: x => x.frontId,
                        principalTable: "infFrontStyle",
                        principalColumn: "frontId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_datSuit_infLapelStyle_lapelId",
                        column: x => x.lapelId,
                        principalTable: "infLapelStyle",
                        principalColumn: "lapelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_datSuit_infOccasionStyle_styleId",
                        column: x => x.styleId,
                        principalTable: "infOccasionStyle",
                        principalColumn: "styleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_datSuit_infSuitType_suitTypeId",
                        column: x => x.suitTypeId,
                        principalTable: "infSuitType",
                        principalColumn: "suitTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_datSuit_infOccasionType_typeId",
                        column: x => x.typeId,
                        principalTable: "infOccasionType",
                        principalColumn: "typeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_datSuit_infVentStyle_ventId",
                        column: x => x.ventId,
                        principalTable: "infVentStyle",
                        principalColumn: "ventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "datSuitDetail",
                columns: table => new
                {
                    detailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    suitId = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    qty = table.Column<int>(nullable: false),
                    tagId = table.Column<int>(nullable: false),
                    inStock = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datSuitDetail", x => x.detailId);
                    table.ForeignKey(
                        name: "FK_datSuitDetail_datSuit_suitId",
                        column: x => x.suitId,
                        principalTable: "datSuit",
                        principalColumn: "suitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "datAppointmentDetail",
                columns: table => new
                {
                    appointmentDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    appointmentId = table.Column<int>(nullable: false),
                    detailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datAppointmentDetail", x => x.appointmentDetailId);
                    table.ForeignKey(
                        name: "FK_datAppointmentDetail_datAppointment_appointmentId",
                        column: x => x.appointmentId,
                        principalTable: "datAppointment",
                        principalColumn: "appointmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_datAppointmentDetail_datSuitDetail_detailId",
                        column: x => x.detailId,
                        principalTable: "datSuitDetail",
                        principalColumn: "detailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_datAppointmentDetail_appointmentId",
                table: "datAppointmentDetail",
                column: "appointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_datAppointmentDetail_detailId",
                table: "datAppointmentDetail",
                column: "detailId");

            migrationBuilder.CreateIndex(
                name: "IX_datSuit_fitId",
                table: "datSuit",
                column: "fitId");

            migrationBuilder.CreateIndex(
                name: "IX_datSuit_frontId",
                table: "datSuit",
                column: "frontId");

            migrationBuilder.CreateIndex(
                name: "IX_datSuit_lapelId",
                table: "datSuit",
                column: "lapelId");

            migrationBuilder.CreateIndex(
                name: "IX_datSuit_styleId",
                table: "datSuit",
                column: "styleId");

            migrationBuilder.CreateIndex(
                name: "IX_datSuit_suitTypeId",
                table: "datSuit",
                column: "suitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_datSuit_typeId",
                table: "datSuit",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_datSuit_ventId",
                table: "datSuit",
                column: "ventId");

            migrationBuilder.CreateIndex(
                name: "IX_datSuitDetail_suitId",
                table: "datSuitDetail",
                column: "suitId");

            migrationBuilder.CreateIndex(
                name: "IX_infOccasionType_labelId",
                table: "infOccasionType",
                column: "labelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "datAppointmentDetail");

            migrationBuilder.DropTable(
                name: "datRole");

            migrationBuilder.DropTable(
                name: "datUserRole");

            migrationBuilder.DropTable(
                name: "infFabric");

            migrationBuilder.DropTable(
                name: "infSalesTag");

            migrationBuilder.DropTable(
                name: "infSuitSize");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "datAppointment");

            migrationBuilder.DropTable(
                name: "datSuitDetail");

            migrationBuilder.DropTable(
                name: "datSuit");

            migrationBuilder.DropTable(
                name: "infOccasionFit");

            migrationBuilder.DropTable(
                name: "infFrontStyle");

            migrationBuilder.DropTable(
                name: "infLapelStyle");

            migrationBuilder.DropTable(
                name: "infOccasionStyle");

            migrationBuilder.DropTable(
                name: "infSuitType");

            migrationBuilder.DropTable(
                name: "infOccasionType");

            migrationBuilder.DropTable(
                name: "infVentStyle");

            migrationBuilder.DropTable(
                name: "infOccasionLabel");
        }
    }
}
