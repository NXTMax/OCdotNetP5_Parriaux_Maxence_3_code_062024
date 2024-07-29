using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressVoituresWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Finition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModels_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Vin = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<float>(type: "real", nullable: false),
                    PurchaseDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResellPrice = table.Column<float>(type: "real", nullable: true),
                    ResellDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Vin);
                    table.ForeignKey(
                        name: "FK_Cars_CarModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarRepairs",
                columns: table => new
                {
                    CarVin = table.Column<int>(type: "int", nullable: false),
                    RepairId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRepairs", x => new { x.CarVin, x.RepairId });
                    table.ForeignKey(
                        name: "FK_CarRepairs_Cars_CarVin",
                        column: x => x.CarVin,
                        principalTable: "Cars",
                        principalColumn: "Vin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRepairs_Repairs_RepairId",
                        column: x => x.RepairId,
                        principalTable: "Repairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_ManufacturerId",
                table: "CarModels",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRepairs_RepairId",
                table: "CarRepairs",
                column: "RepairId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                column: "ModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRepairs");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
