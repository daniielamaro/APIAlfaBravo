using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AutorId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Content = table.Column<string>(maxLength: 1200, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    TopicId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publications_Users_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publications_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AutorId = table.Column<Guid>(nullable: true),
                    Content = table.Column<string>(maxLength: 1200, nullable: false),
                    PublicationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Publications_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("025ed755-8dfe-48dd-87d8-f16da5de1522"), "Cultura" },
                    { new Guid("d9eaa5d9-b871-4a1f-9287-f502cc6517b3"), "Economia" },
                    { new Guid("468e40a9-368f-48ab-b525-68414e81eba0"), "Educação" },
                    { new Guid("0e2ad91b-6a3c-4228-9006-b213b6857df0"), "Entretenimento" },
                    { new Guid("d61d8c92-a7f5-496b-9559-cfa27e5033d3"), "Esporte" },
                    { new Guid("7d1710aa-cde3-42a5-be34-eb0f7a3e167d"), "Política" },
                    { new Guid("fae89cce-90ed-43a9-aa8d-5d7aafad7ced"), "Saúde" },
                    { new Guid("4de6ef52-67f4-4ee7-81c7-44ec12f4c08e"), "Tecnologia" },
                    { new Guid("4e9edd2c-55cb-467f-9755-25b0b520f134"), "Tempo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AutorId",
                table: "Comments",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PublicationId",
                table: "Comments",
                column: "PublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_AutorId",
                table: "Publications",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_TopicId",
                table: "Publications",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
