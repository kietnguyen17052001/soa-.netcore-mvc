using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManager.Migrations
{
    public partial class AddSlugInProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "product",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slug",
                table: "product");
        }
    }
}
