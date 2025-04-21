using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressVoituresWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinitionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finition",
                table: "CarModels");

            migrationBuilder.AddColumn<string>(
                name: "FinitionName",
                table: "CarModels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ModelFinition",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelFinition", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_FinitionName",
                table: "CarModels",
                column: "FinitionName");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_ModelFinition_FinitionName",
                table: "CarModels",
                column: "FinitionName",
                principalTable: "ModelFinition",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_ModelFinition_FinitionName",
                table: "CarModels");

            migrationBuilder.DropTable(
                name: "ModelFinition");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_FinitionName",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "FinitionName",
                table: "CarModels");

            migrationBuilder.AddColumn<string>(
                name: "Finition",
                table: "CarModels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
