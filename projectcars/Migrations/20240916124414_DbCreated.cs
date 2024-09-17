using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectcars.Migrations
{
    /// <inheritdoc />
    public partial class DbCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Generations",
                columns: table => new
                {
                    GenerationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenerationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Restyling = table.Column<bool>(type: "bit", nullable: false),
                    StartYear = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    EndYear = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generations", x => x.GenerationId);
                    table.ForeignKey(
                        name: "FK_Generations_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", maxLength: 50, nullable: false),
                    EngineVolume = table.Column<double>(type: "float", maxLength: 10, nullable: false),
                    TransmissionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BodyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EngineType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DriveTrain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnginePower = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Mileage = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Abs = table.Column<bool>(type: "bit", nullable: false),
                    Esp = table.Column<bool>(type: "bit", nullable: false),
                    Asr = table.Column<bool>(type: "bit", nullable: false),
                    Immobilizer = table.Column<bool>(type: "bit", nullable: false),
                    Signaling = table.Column<bool>(type: "bit", nullable: false),
                    GenerationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Generations_GenerationId",
                        column: x => x.GenerationId,
                        principalTable: "Generations",
                        principalColumn: "GenerationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GenerationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId");
                    table.ForeignKey(
                        name: "FK_Images_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Generations_GenerationId",
                        column: x => x.GenerationId,
                        principalTable: "Generations",
                        principalColumn: "GenerationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_BrandName",
                table: "Brands",
                column: "BrandName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_GenerationId",
                table: "Cars",
                column: "GenerationId");

            migrationBuilder.CreateIndex(
                name: "IX_Generations_GenerationName",
                table: "Generations",
                column: "GenerationName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Generations_ModelId",
                table: "Generations",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_BrandId",
                table: "Images",
                column: "BrandId",
                unique: true,
                filter: "[BrandId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CarId",
                table: "Images",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_GenerationId",
                table: "Images",
                column: "GenerationId",
                unique: true,
                filter: "[GenerationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImagePath",
                table: "Images",
                column: "ImagePath",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ModelName",
                table: "Models",
                column: "ModelName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Generations");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
