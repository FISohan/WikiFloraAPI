using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiFloraAPI.Migrations
{
    /// <inheritdoc />
    public partial class FloraRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Floras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BanglaName = table.Column<string>(type: "TEXT", nullable: false),
                    AlphabetIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    OthersName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Contributer = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hierarchy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FloraId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Kingdom = table.Column<string>(type: "TEXT", nullable: false),
                    Family = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<string>(type: "TEXT", nullable: false),
                    Genus = table.Column<string>(type: "TEXT", nullable: false),
                    Species = table.Column<string>(type: "TEXT", nullable: false),
                    BionomialName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hierarchy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hierarchy_Floras_FloraId",
                        column: x => x.FloraId,
                        principalTable: "Floras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScientificName",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FloraId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Genus = table.Column<string>(type: "TEXT", nullable: false),
                    SpecificEpithet = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScientificName_Floras_FloraId",
                        column: x => x.FloraId,
                        principalTable: "Floras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FloraPhoto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FloraId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CoverPhotoUrlId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloraPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FloraPhoto_Floras_FloraId",
                        column: x => x.FloraId,
                        principalTable: "Floras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FloraId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Reference = table.Column<string>(type: "TEXT", nullable: true),
                    Credit = table.Column<string>(type: "TEXT", nullable: true),
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
                name: "IX_FloraPhoto_CoverPhotoUrlId",
                table: "FloraPhoto",
                column: "CoverPhotoUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_FloraPhoto_FloraId",
                table: "FloraPhoto",
                column: "FloraId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchy_FloraId",
                table: "Hierarchy",
                column: "FloraId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_FloraPhotoId",
                table: "Photo",
                column: "FloraPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificName_FloraId",
                table: "ScientificName",
                column: "FloraId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FloraPhoto_Photo_CoverPhotoUrlId",
                table: "FloraPhoto",
                column: "CoverPhotoUrlId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FloraPhoto_Floras_FloraId",
                table: "FloraPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_FloraPhoto_Photo_CoverPhotoUrlId",
                table: "FloraPhoto");

            migrationBuilder.DropTable(
                name: "Hierarchy");

            migrationBuilder.DropTable(
                name: "ScientificName");

            migrationBuilder.DropTable(
                name: "Floras");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "FloraPhoto");
        }
    }
}
