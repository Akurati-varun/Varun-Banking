using Microsoft.EntityFrameworkCore.Migrations;

namespace Varun_Banking.Migrations
{
    public partial class tablecreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VarunBank",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: false),
                    AccountType = table.Column<int>(nullable: false),
                    Contact = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<long>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarunBank", x => x.CustomerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VarunBank");
        }
    }
}
