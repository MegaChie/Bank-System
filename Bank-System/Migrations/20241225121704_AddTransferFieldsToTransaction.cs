using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_System.Migrations
{
    /// <inheritdoc />
    public partial class AddTransferFieldsToTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverAccountID",
                table: "Transactions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderAccountID",
                table: "Transactions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ReceiverAccountID",
                table: "Transactions",
                column: "ReceiverAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SenderAccountID",
                table: "Transactions",
                column: "SenderAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_ReceiverAccountID",
                table: "Transactions",
                column: "ReceiverAccountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_SenderAccountID",
                table: "Transactions",
                column: "SenderAccountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_ReceiverAccountID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_SenderAccountID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ReceiverAccountID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_SenderAccountID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ReceiverAccountID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SenderAccountID",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountID",
                table: "Transactions",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountID",
                table: "Transactions",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
