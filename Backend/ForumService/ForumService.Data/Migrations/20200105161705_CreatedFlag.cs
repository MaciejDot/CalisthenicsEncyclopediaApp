using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumService.Data.Migrations
{
    public partial class CreatedFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Edited",
                schema: "Forum",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edited",
                schema: "Forum",
                table: "Posts");
        }
    }
}
