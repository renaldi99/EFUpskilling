using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFUpskilling.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mt_customer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customername = table.Column<string>(name: "customer_name", type: "NVarchar(50)", nullable: false),
                    address = table.Column<string>(type: "NVarchar(100)", nullable: false),
                    mobilephone = table.Column<string>(name: "mobile_phone", type: "NVarchar(14)", nullable: false),
                    email = table.Column<string>(type: "NVarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mt_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mt_product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productname = table.Column<string>(name: "product_name", type: "NVarchar(50)", nullable: true),
                    productprice = table.Column<long>(name: "product_price", type: "bigint", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mt_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mt_purchase",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    transdate = table.Column<DateTime>(name: "trans_date", type: "datetime2", nullable: false),
                    customerid = table.Column<Guid>(name: "customer_id", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mt_purchase", x => x.id);
                    table.ForeignKey(
                        name: "FK_mt_purchase_mt_customer_customer_id",
                        column: x => x.customerid,
                        principalTable: "mt_customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mt_purchase_detail",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    purchaseid = table.Column<Guid>(name: "purchase_id", type: "uniqueidentifier", nullable: false),
                    productid = table.Column<Guid>(name: "product_id", type: "uniqueidentifier", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mt_purchase_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_mt_purchase_detail_mt_product_product_id",
                        column: x => x.productid,
                        principalTable: "mt_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mt_purchase_detail_mt_purchase_purchase_id",
                        column: x => x.purchaseid,
                        principalTable: "mt_purchase",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mt_purchase_customer_id",
                table: "mt_purchase",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_mt_purchase_detail_product_id",
                table: "mt_purchase_detail",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_mt_purchase_detail_purchase_id",
                table: "mt_purchase_detail",
                column: "purchase_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mt_purchase_detail");

            migrationBuilder.DropTable(
                name: "mt_product");

            migrationBuilder.DropTable(
                name: "mt_purchase");

            migrationBuilder.DropTable(
                name: "mt_customer");
        }
    }
}
