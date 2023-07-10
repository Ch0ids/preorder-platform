using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PreorderPlatform.Entity.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    owner_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessPaymentCredential",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    business_id = table.Column<int>(type: "int", nullable: true),
                    bank_account_number = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    bank_name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    bank_recipient_name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    momo_api_key = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    momo_partner_code = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    momo_access_token = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    momo_secret_token = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    is_momo_active = table.Column<bool>(type: "bit", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPaymentCredential", x => x.id);
                    table.ForeignKey(
                        name: "FK__BusinessP__busin__403A8C7D",
                        column: x => x.business_id,
                        principalTable: "Business",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    business_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK__Product__busines__49C3F6B7",
                        column: x => x.business_id,
                        principalTable: "Business",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Product__categor__48CFD27E",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    district = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    business_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK__User__business_i__3D5E1FD2",
                        column: x => x.business_id,
                        principalTable: "Business",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__User__role_id__398D8EEE",
                        column: x => x.role_id,
                        principalTable: "Role",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    start_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    end_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    deposit_percent = table.Column<int>(type: "int", nullable: true),
                    expected_shipping_date = table.Column<DateTime>(type: "date", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    owner_id = table.Column<int>(type: "int", nullable: true),
                    business_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.id);
                    table.ForeignKey(
                        name: "FK__Campaign__busine__440B1D61",
                        column: x => x.business_id,
                        principalTable: "Business",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Campaign__owner___4316F928",
                        column: x => x.owner_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    total_quantity = table.Column<int>(type: "int", nullable: true),
                    total_price = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    is_deposited = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    revicer_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    revicer_phone = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    shipping_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shipping_province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shipping_ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shipping_district = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shipping_code = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    shipping_price = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    shipping_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK__Order__user_id__5070F446",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CampaignDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    phase = table.Column<int>(type: "int", nullable: false),
                    allowed_quantity = table.Column<int>(type: "int", nullable: false),
                    total_ordered = table.Column<int>(type: "int", nullable: false),
                    campaign_id = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK__CampaignD__campa__4CA06362",
                        column: x => x.campaign_id,
                        principalTable: "Campaign",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__CampaignD__produ__4D94879B",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    payment_count = table.Column<int>(type: "int", nullable: true),
                    payed_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    order_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.id);
                    table.ForeignKey(
                        name: "FK__Payment__order_i__5812160E",
                        column: x => x.order_id,
                        principalTable: "Order",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Payment__user_id__571DF1D5",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    campaign_detail_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    unit_price = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    order_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.id);
                    table.ForeignKey(
                        name: "FK__OrderItem__campa__5441852A",
                        column: x => x.campaign_detail_id,
                        principalTable: "CampaignDetail",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__OrderItem__order__534D60F1",
                        column: x => x.order_id,
                        principalTable: "Order",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_owner_id",
                table: "Business",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPaymentCredential_business_id",
                table: "BusinessPaymentCredential",
                column: "business_id");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_business_id",
                table: "Campaign",
                column: "business_id");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_owner_id",
                table: "Campaign",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignDetail_campaign_id",
                table: "CampaignDetail",
                column: "campaign_id");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignDetail_product_id",
                table: "CampaignDetail",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_user_id",
                table: "Order",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_campaign_detail_id",
                table: "OrderItem",
                column: "campaign_detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_order_id",
                table: "OrderItem",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_order_id",
                table: "Payment",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_user_id",
                table: "Payment",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_business_id",
                table: "Product",
                column: "business_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_category_id",
                table: "Product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_business_id",
                table: "User",
                column: "business_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_role_id",
                table: "User",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Business__owner___3C69FB99",
                table: "Business",
                column: "owner_id",
                principalTable: "User",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Business__owner___3C69FB99",
                table: "Business");

            migrationBuilder.DropTable(
                name: "BusinessPaymentCredential");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "CampaignDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
