using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiFloraAPI.Migrations
{
    /// <inheritdoc />
    public partial class FloraRelationshipV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCoverPhoto",
                table: "Photo",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCoverPhoto",
                table: "Photo");
        }
    }
}
