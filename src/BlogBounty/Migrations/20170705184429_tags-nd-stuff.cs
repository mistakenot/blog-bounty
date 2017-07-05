using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogBounty.Migrations
{
    public partial class tagsndstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_UserId1",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_UserId1",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Topics");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Topics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UserId",
                table: "Topics",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_UserId",
                table: "Topics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_UserId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_UserId",
                table: "Topics");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Topics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Topics",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Topics",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UserId1",
                table: "Topics",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_UserId1",
                table: "Topics",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
