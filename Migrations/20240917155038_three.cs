using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalleryApp.Migrations
{
    /// <inheritdoc />
    public partial class three : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "images");

            migrationBuilder.RenameColumn(
                name: "ContentType",
                table: "images",
                newName: "ImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "images",
                newName: "ContentType");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "images",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
