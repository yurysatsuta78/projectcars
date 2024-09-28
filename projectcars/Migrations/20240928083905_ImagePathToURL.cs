using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectcars.Migrations
{
    /// <inheritdoc />
    public partial class ImagePathToURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Images",
                newName: "ImageUrl");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ImagePath",
                table: "Images",
                newName: "IX_Images_ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Images",
                newName: "ImagePath");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ImageUrl",
                table: "Images",
                newName: "IX_Images_ImagePath");
        }
    }
}
