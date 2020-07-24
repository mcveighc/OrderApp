using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BGLOrderApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "Item_seq",
                startValue: 0L);

            migrationBuilder.CreateSequence<int>(
                name: "Order_seq",
                startValue: 0L);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR Item_seq"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR Order_seq"),
                    Total = table.Column<decimal>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    ItemQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Name", "Price", "Status" },
                values: new object[,]
                {
                    { 9, "Item 1 Description", "Item 1", 10.99m, 0 },
                    { 1, "Item 2 Description", "Item 2", 10.99m, 0 },
                    { 2, "Item 3 Description", "Item 3", 10.99m, 0 },
                    { 3, "Item 4 Description", "Item 4", 10.99m, 1 },
                    { 4, "Item 5 Description", "Item 5", 10.99m, 0 },
                    { 5, "Item 6 Description", "Item 6", 10.99m, 1 },
                    { 6, "Item 7 Description", "Item 7", 10.99m, 0 },
                    { 7, "Item 8 Description", "Item 8", 10.99m, 2 },
                    { 8, "Item 9 Description", "Item 9", 10.99m, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ItemId",
                table: "OrderDetails",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropSequence(
                name: "Item_seq");

            migrationBuilder.DropSequence(
                name: "Order_seq");
        }
    }
}
