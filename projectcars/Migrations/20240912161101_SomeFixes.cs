using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectcars.Migrations
{
    /// <inheritdoc />
    public partial class SomeFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Immobilazer",
                table: "Cars",
                newName: "IsHidden");

            migrationBuilder.AddColumn<bool>(
                name: "Immobilizer",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Immobilizer",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "IsHidden",
                table: "Cars",
                newName: "Immobilazer");
        }
    }
}
