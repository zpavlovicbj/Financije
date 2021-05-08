using Microsoft.EntityFrameworkCore.Migrations;

namespace Financije.Persistence.Migrations
{
    public partial class LinksArtDes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescriptionId",
                table: "Descriptions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AccountsId",
                table: "Accounts",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "NameAccount",
                table: "Stores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameUC",
                table: "Stores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameUC",
                table: "Articles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "LinksArtDes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinksArtDes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinksArtDes_Descriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "Descriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinksArtDes_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinksArtDes_DescriptionId",
                table: "LinksArtDes",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_LinksArtDes_StoreId",
                table: "LinksArtDes",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinksArtDes");

            migrationBuilder.DropColumn(
                name: "NameAccount",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "NameUC",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "NameUC",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Descriptions",
                newName: "DescriptionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Accounts",
                newName: "AccountsId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
