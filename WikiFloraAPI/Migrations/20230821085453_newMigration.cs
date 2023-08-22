using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiFloraAPI.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credit",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "BionomialName",
                table: "Hierarchy");

            migrationBuilder.AddColumn<string>(
                name: "reference",
                table: "Floras",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reference",
                table: "Floras");

            migrationBuilder.AddColumn<string>(
                name: "Credit",
                table: "Photo",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Photo",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BionomialName",
                table: "Hierarchy",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
