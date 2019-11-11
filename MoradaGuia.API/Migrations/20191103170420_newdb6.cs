using Microsoft.EntityFrameworkCore.Migrations;

namespace MoradaGuia.API.Migrations
{
    public partial class newdb6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Imovel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Imovel",
                nullable: true);
        }
    }
}
