using Microsoft.EntityFrameworkCore.Migrations;

namespace Aunt_Irma_Shop.Data.Migrations
{
    public partial class addCouponToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Coupon",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Coupon");
        }
    }
}
