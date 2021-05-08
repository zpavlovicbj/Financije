using Microsoft.EntityFrameworkCore.Migrations;

namespace Financije.Persistence.Migrations
{
    public partial class Nekepromijene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameUC",
                table: "Stores",
                newName: "StoreNameUC");

            migrationBuilder.RenameColumn(
                name: "NameAccount",
                table: "Stores",
                newName: "StoreNameAccount");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stores",
                newName: "StoreName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stores",
                newName: "StoreId");

            migrationBuilder.RenameColumn(
                name: "NameUC",
                table: "Descriptions",
                newName: "DescriptionNameUC");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Descriptions",
                newName: "DescriptionName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Descriptions",
                newName: "DescriptionId");

            migrationBuilder.RenameColumn(
                name: "NameUC",
                table: "Articles",
                newName: "ArticleNameUC");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Articles",
                newName: "ArticleName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Articles",
                newName: "ArticleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Accounts",
                newName: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoreNameUC",
                table: "Stores",
                newName: "NameUC");

            migrationBuilder.RenameColumn(
                name: "StoreNameAccount",
                table: "Stores",
                newName: "NameAccount");

            migrationBuilder.RenameColumn(
                name: "StoreName",
                table: "Stores",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "Stores",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DescriptionNameUC",
                table: "Descriptions",
                newName: "NameUC");

            migrationBuilder.RenameColumn(
                name: "DescriptionName",
                table: "Descriptions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DescriptionId",
                table: "Descriptions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ArticleNameUC",
                table: "Articles",
                newName: "NameUC");

            migrationBuilder.RenameColumn(
                name: "ArticleName",
                table: "Articles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "Articles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Accounts",
                newName: "Id");
        }
    }
}
