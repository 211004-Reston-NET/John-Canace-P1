using Microsoft.EntityFrameworkCore.Migrations;

namespace SFDL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    cus_customerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_name = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    customer_address = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    customer_email = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    customer_phone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cus_PK", x => x.cus_customerID);
                });

            migrationBuilder.CreateTable(
                name: "StoreFront",
                columns: table => new
                {
                    store_storeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_name = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    store_address = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    ProductsList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sto_PK", x => x.store_storeID);
                });

            migrationBuilder.CreateTable(
                name: "OrderList",
                columns: table => new
                {
                    order_orderListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_totalprice = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0))"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    order_storeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ord_PK", x => x.order_orderListID);
                    table.ForeignKey(
                        name: "ord_cus_FK",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "cus_customerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ord_sto_FK",
                        column: x => x.order_storeID,
                        principalTable: "StoreFront",
                        principalColumn: "store_storeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    product_productnameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    product_price = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0))"),
                    product_description = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    product_category = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    store_storeID = table.Column<int>(type: "int", nullable: false),
                    product_quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pro_PK", x => x.product_productnameID);
                    table.ForeignKey(
                        name: "pro_sto_FK",
                        column: x => x.store_storeID,
                        principalTable: "StoreFront",
                        principalColumn: "store_storeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    line_itemnameID = table.Column<int>(type: "int", nullable: false),
                    lineItemList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    line_storeID = table.Column<int>(type: "int", nullable: false),
                    line_orderListID = table.Column<int>(type: "int", nullable: false),
                    line_itemquantity = table.Column<int>(type: "int", nullable: false),
                    OrderList = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("lin_PK", x => x.line_itemnameID);
                    table.ForeignKey(
                        name: "FK_LineItem_OrderList_OrderList",
                        column: x => x.OrderList,
                        principalTable: "OrderList",
                        principalColumn: "order_orderListID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "lin_ord_FK",
                        column: x => x.line_orderListID,
                        principalTable: "OrderList",
                        principalColumn: "order_orderListID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "lin_pro_FK",
                        column: x => x.line_itemnameID,
                        principalTable: "Product",
                        principalColumn: "product_productnameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "lin_sto_FK",
                        column: x => x.line_storeID,
                        principalTable: "StoreFront",
                        principalColumn: "store_storeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_line_orderListID",
                table: "LineItem",
                column: "line_orderListID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_line_storeID",
                table: "LineItem",
                column: "line_storeID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_OrderList",
                table: "LineItem",
                column: "OrderList");

            migrationBuilder.CreateIndex(
                name: "IX_OrderList_CustomerID",
                table: "OrderList",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderList_order_storeID",
                table: "OrderList",
                column: "order_storeID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_store_storeID",
                table: "Product",
                column: "store_storeID");

            migrationBuilder.CreateIndex(
                name: "sto_UC_address",
                table: "StoreFront",
                column: "store_address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "sto_UC_name",
                table: "StoreFront",
                column: "store_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "OrderList");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "StoreFront");
        }
    }
}
