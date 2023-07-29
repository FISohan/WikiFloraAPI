using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiFloraAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddFloraAndFloraPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hierarchy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    kingdom = table.Column<string>(type: "TEXT", nullable: false),
                    family = table.Column<string>(type: "TEXT", nullable: false),
                    order = table.Column<string>(type: "TEXT", nullable: false),
                    genus = table.Column<string>(type: "TEXT", nullable: false),
                    species = table.Column<string>(type: "TEXT", nullable: false),
                    bionomialName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hierarchy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScientificName",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    genus = table.Column<string>(type: "TEXT", nullable: false),
                    specificEpithet = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FloraPhoto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    floraId = table.Column<string>(type: "TEXT", nullable: false),
                    floraName = table.Column<string>(type: "TEXT", nullable: false),
                    coverPhotoUrlId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloraPhoto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    banglaName = table.Column<string>(type: "TEXT", nullable: false),
                    englishName = table.Column<string>(type: "TEXT", nullable: false),
                    ScientificNameId = table.Column<Guid>(type: "TEXT", nullable: false),
                    othersName = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    contributer = table.Column<string>(type: "TEXT", nullable: false),
                    floraPhotoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    hierarchyId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floras_FloraPhoto_floraPhotoId",
                        column: x => x.floraPhotoId,
                        principalTable: "FloraPhoto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Floras_Hierarchy_hierarchyId",
                        column: x => x.hierarchyId,
                        principalTable: "Hierarchy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Floras_ScientificName_ScientificNameId",
                        column: x => x.ScientificNameId,
                        principalTable: "ScientificName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    url = table.Column<string>(type: "TEXT", nullable: false),
                    FloraPhotoId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_FloraPhoto_FloraPhotoId",
                        column: x => x.FloraPhotoId,
                        principalTable: "FloraPhoto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FloraPhoto_coverPhotoUrlId",
                table: "FloraPhoto",
                column: "coverPhotoUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_Floras_floraPhotoId",
                table: "Floras",
                column: "floraPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Floras_hierarchyId",
                table: "Floras",
                column: "hierarchyId");

            migrationBuilder.CreateIndex(
                name: "IX_Floras_ScientificNameId",
                table: "Floras",
                column: "ScientificNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_FloraPhotoId",
                table: "Photo",
                column: "FloraPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_FloraPhoto_Photo_coverPhotoUrlId",
                table: "FloraPhoto",
                column: "coverPhotoUrlId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FloraPhoto_Photo_coverPhotoUrlId",
                table: "FloraPhoto");

            migrationBuilder.DropTable(
                name: "Floras");

            migrationBuilder.DropTable(
                name: "Hierarchy");

            migrationBuilder.DropTable(
                name: "ScientificName");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "FloraPhoto");
        }
    }
}
