using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoradaGuia.API.Migrations
{
    public partial class AddUserCommentImmobileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    PasswordHash = table.Column<byte[]>(maxLength: 20, nullable: false),
                    PasswordSalt = table.Column<byte[]>(maxLength: 20, nullable: false),
                    nome = table.Column<string>(maxLength: 20, nullable: false),
                    sobrenome = table.Column<string>(maxLength: 40, nullable: false),
                    telefone = table.Column<int>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
