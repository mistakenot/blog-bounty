using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogBounty.Migrations
{
    public partial class notsure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Tags");

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Tags",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "Tags");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Tags",
                nullable: true);
        }
    }
}
