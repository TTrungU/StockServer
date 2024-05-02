using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class update_userEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Users",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Users");
        }
    }
}
