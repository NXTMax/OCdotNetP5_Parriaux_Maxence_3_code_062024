using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressVoituresWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCarDescAndImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Cars");
        }
    }
}
