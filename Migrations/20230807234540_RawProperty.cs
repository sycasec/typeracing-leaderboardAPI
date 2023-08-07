using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace typeRacingAPI.Migrations
{
    /// <inheritdoc />
    public partial class RawProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Raw",
                table: "Players",
                type: "real",
                nullable: false,
                defaultValue: 0f);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Raw",
                table: "Players");
        }
    }
}
