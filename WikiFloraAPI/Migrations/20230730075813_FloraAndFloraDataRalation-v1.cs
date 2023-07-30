using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiFloraAPI.Migrations
{
    /// <inheritdoc />
    public partial class FloraAndFloraDataRalationv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Floras_FloraId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_FloraId",
                table: "Photo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Photo_FloraId",
                table: "Photo",
                column: "FloraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Floras_FloraId",
                table: "Photo",
                column: "FloraId",
                principalTable: "Floras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
