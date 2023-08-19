using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStoreApplication.Migrations
{
    public partial class AddUniqueConstarint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserName1",
                table: "Customers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
               name: "IX_Customers_Password",
               table: "Customers",
               column: "Password",
               unique: true);

            /*This will fail as Email was declared as nvarchar and unique contraint is only on numeric types (like integers) or fixed-length character types (like CHAR or NCHAR).*/
            //migrationBuilder.CreateIndex(
            //  name: "IX_Customers_Email",
            //  table: "Customers",
            //  column: "Email",
            //  unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
