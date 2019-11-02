using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MoradaGuia.API.Migrations
{
    public partial class newdb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Qtd_Quarto",
                table: "Imovel",
                newName: "QtdQuarto");

            migrationBuilder.RenameColumn(
                name: "Qtd_Banheiro",
                table: "Imovel",
                newName: "QtdBanheiro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QtdQuarto",
                table: "Imovel",
                newName: "Qtd_Quarto");

            migrationBuilder.RenameColumn(
                name: "QtdBanheiro",
                table: "Imovel",
                newName: "Qtd_Banheiro");

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

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Comment = table.Column<string>(nullable: true),
                    Email_FK = table.Column<string>(nullable: true),
                    Id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentario_Usuario_Email_FK",
                        column: x => x.Email_FK,
                        principalTable: "Usuario",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentario_Imovel_Id_FK",
                        column: x => x.Id_FK,
                        principalTable: "Imovel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_Email_FK",
                table: "Comentario",
                column: "Email_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_Id_FK",
                table: "Comentario",
                column: "Id_FK");
        }
    }
}
