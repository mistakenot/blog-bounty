using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlogBounty.Migrations
{
    public partial class subs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TopicId = table.Column<int>(nullable: false),
                    Uri = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submissions_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Topics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Topics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UserId1",
                table: "Topics",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_TopicId",
                table: "Submissions",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_UserId",
                table: "Submissions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_UserId1",
                table: "Topics",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_UserId1",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_UserId1",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Topics");

            migrationBuilder.DropTable(
                name: "Submissions");
        }
    }
}
