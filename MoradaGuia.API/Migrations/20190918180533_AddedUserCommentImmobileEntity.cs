using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MoradaGuia.API.Migrations
{
    public partial class AddedUserCommentImmobileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imovel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Tipo = table.Column<string>(maxLength: 20, nullable: false),
                    Rua = table.Column<string>(maxLength: 40, nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(maxLength: 30, nullable: false),
                    Valor = table.Column<float>(nullable: false),
                    Qtd_Quarto = table.Column<int>(nullable: false),
                    Qtd_Banheiro = table.Column<int>(nullable: false),
                    Garagem = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Imagem = table.Column<byte[]>(nullable: false),
                    Email_FK = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imovel_Usuario_Email_FK",
                        column: x => x.Email_FK,
                        principalTable: "Usuario",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Email_FK = table.Column<string>(nullable: true),
                    Id_FK = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Imovel_Email_FK",
                table: "Imovel",
                column: "Email_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Imovel");
        }
    }
}
