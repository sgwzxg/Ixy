using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ixy.Web.Migrations
{
    public partial class InitPostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
