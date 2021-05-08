using Microsoft.EntityFrameworkCore.Migrations;

namespace Financije.Persistence.Migrations
{
    public partial class DescriptionNameUc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameUC",
                table: "Descriptions",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameUC",
                table: "Descriptions");
        }
    }
}
