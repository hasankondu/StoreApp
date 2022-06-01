using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreApp.DataAccess.Migrations
{
    public partial class AddingCartEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartID",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductID",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorieSubs_Categories_CategoryID",
                table: "CategorieSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteItems_Favorites_FavoriteID",
                table: "FavoriteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteItems_Products_ProductID",
                table: "FavoriteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserID",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderID",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductID",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategorySub_CategorieSubs_CategorySubID",
                table: "ProductCategorySub");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_UserID",
                table: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteItems",
                table: "FavoriteItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategorieSubs",
                table: "CategorieSubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItem");

            migrationBuilder.RenameTable(
                name: "FavoriteItems",
                newName: "FavoriteItem");

            migrationBuilder.RenameTable(
                name: "CategorieSubs",
                newName: "CategorySubs");

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "CartItem");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductID",
                table: "OrderItem",
                newName: "IX_OrderItem_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteItems_ProductID",
                table: "FavoriteItem",
                newName: "IX_FavoriteItem_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteItems_FavoriteID",
                table: "FavoriteItem",
                newName: "IX_FavoriteItem_FavoriteID");

            migrationBuilder.RenameIndex(
                name: "IX_CategorieSubs_CategoryID",
                table: "CategorySubs",
                newName: "IX_CategorySubs_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ProductID",
                table: "CartItem",
                newName: "IX_CartItem_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartID",
                table: "CartItem",
                newName: "IX_CartItem_CartID");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "OrderItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteItem",
                table: "FavoriteItem",
                column: "FavoriteItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategorySubs",
                table: "CategorySubs",
                column: "CategorySubID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem",
                column: "CartItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Carts_CartID",
                table: "CartItem",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Products_ProductID",
                table: "CartItem",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorySubs_Categories_CategoryID",
                table: "CategorySubs",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteItem_Favorites_FavoriteID",
                table: "FavoriteItem",
                column: "FavoriteID",
                principalTable: "Favorites",
                principalColumn: "FavoriteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteItem_Products_ProductID",
                table: "FavoriteItem",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_OrderID",
                table: "OrderItem",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Products_ProductID",
                table: "OrderItem",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategorySub_CategorySubs_CategorySubID",
                table: "ProductCategorySub",
                column: "CategorySubID",
                principalTable: "CategorySubs",
                principalColumn: "CategorySubID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Carts_CartID",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Products_ProductID",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CategorySubs_Categories_CategoryID",
                table: "CategorySubs");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteItem_Favorites_FavoriteID",
                table: "FavoriteItem");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteItem_Products_ProductID",
                table: "FavoriteItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_OrderID",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Products_ProductID",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategorySub_CategorySubs_CategorySubID",
                table: "ProductCategorySub");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteItem",
                table: "FavoriteItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategorySubs",
                table: "CategorySubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "FavoriteItem",
                newName: "FavoriteItems");

            migrationBuilder.RenameTable(
                name: "CategorySubs",
                newName: "CategorieSubs");

            migrationBuilder.RenameTable(
                name: "CartItem",
                newName: "CartItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ProductID",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderID",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteItem_ProductID",
                table: "FavoriteItems",
                newName: "IX_FavoriteItems_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteItem_FavoriteID",
                table: "FavoriteItems",
                newName: "IX_FavoriteItems_FavoriteID");

            migrationBuilder.RenameIndex(
                name: "IX_CategorySubs_CategoryID",
                table: "CategorieSubs",
                newName: "IX_CategorieSubs_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ProductID",
                table: "CartItems",
                newName: "IX_CartItems_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_CartID",
                table: "CartItems",
                newName: "IX_CartItems_CartID");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 10000,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Favorites",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "OrderItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteItems",
                table: "FavoriteItems",
                column: "FavoriteItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategorieSubs",
                table: "CategorieSubs",
                column: "CategorySubID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "CartItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserID",
                table: "Favorites",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartID",
                table: "CartItems",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductID",
                table: "CartItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategorieSubs_Categories_CategoryID",
                table: "CategorieSubs",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteItems_Favorites_FavoriteID",
                table: "FavoriteItems",
                column: "FavoriteID",
                principalTable: "Favorites",
                principalColumn: "FavoriteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteItems_Products_ProductID",
                table: "FavoriteItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserID",
                table: "Favorites",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderID",
                table: "OrderItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductID",
                table: "OrderItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategorySub_CategorieSubs_CategorySubID",
                table: "ProductCategorySub",
                column: "CategorySubID",
                principalTable: "CategorieSubs",
                principalColumn: "CategorySubID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
