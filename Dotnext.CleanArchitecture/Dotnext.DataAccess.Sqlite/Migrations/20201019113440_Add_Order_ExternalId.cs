using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotnext.DataAccess.Sqlite.Migrations
{
    public partial class Add_Order_ExternalId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Orders");
        }
    }
}
