using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_walletHistories_Wallets_WalletId1",
                table: "walletHistories");

            migrationBuilder.DropIndex(
                name: "IX_walletHistories_WalletId1",
                table: "walletHistories");

            migrationBuilder.DropColumn(
                name: "WalletId1",
                table: "walletHistories");

            migrationBuilder.AlterColumn<int>(
                name: "WalletId",
                table: "walletHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_walletHistories_WalletId",
                table: "walletHistories",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_walletHistories_Wallets_WalletId",
                table: "walletHistories",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_walletHistories_Wallets_WalletId",
                table: "walletHistories");

            migrationBuilder.DropIndex(
                name: "IX_walletHistories_WalletId",
                table: "walletHistories");

            migrationBuilder.AlterColumn<string>(
                name: "WalletId",
                table: "walletHistories",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WalletId1",
                table: "walletHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_walletHistories_WalletId1",
                table: "walletHistories",
                column: "WalletId1");

            migrationBuilder.AddForeignKey(
                name: "FK_walletHistories_Wallets_WalletId1",
                table: "walletHistories",
                column: "WalletId1",
                principalTable: "Wallets",
                principalColumn: "Id");
        }
    }
}
