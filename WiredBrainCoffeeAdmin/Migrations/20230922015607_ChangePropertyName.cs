using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WiredBrainCoffeeAdmin.Migrations
{
    public partial class ChangePropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFile",
                table: "Products",
                newName: "ImageFileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "Products",
                newName: "ImageFile");
        }
    }
}
