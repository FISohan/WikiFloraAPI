using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiFloraAPI.Migrations
{
    /// <inheritdoc />
    public partial class FloraRelationshipV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Floras_AlphabetIndex",
                table: "Floras");

            migrationBuilder.AddColumn<int>(
                name: "GenusIndex",
                table: "Floras",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Floras_AlphabetIndex_GenusIndex",
                table: "Floras",
                columns: new[] { "AlphabetIndex", "GenusIndex" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Floras_AlphabetIndex_GenusIndex",
                table: "Floras");

            migrationBuilder.DropColumn(
                name: "GenusIndex",
                table: "Floras");

            migrationBuilder.CreateIndex(
                name: "IX_Floras_AlphabetIndex",
                table: "Floras",
                column: "AlphabetIndex");
        }
    }
}
