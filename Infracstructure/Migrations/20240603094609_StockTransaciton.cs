using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class StockTransaciton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockId",
                table: "StockTransactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StockId",
                table: "StockTransactions",
                type: "longtext",
                nullable: true);
        }
    }
}
