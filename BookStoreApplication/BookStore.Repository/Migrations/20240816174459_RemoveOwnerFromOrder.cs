using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOwnerFromOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OwnerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Orders",
                newName: "BookStoreApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OwnerId",
                table: "Orders",
                newName: "IX_Orders_BookStoreApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_BookStoreApplicationUserId",
                table: "Orders",
                column: "BookStoreApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_BookStoreApplicationUserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "BookStoreApplicationUserId",
                table: "Orders",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BookStoreApplicationUserId",
                table: "Orders",
                newName: "IX_Orders_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_OwnerId",
                table: "Orders",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
