using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{

    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserName", "Password" }, 
                values: new object[] {"Barba167", "4780aefb6503c07fcc2a18b43b6f3a9065704813e9e838e9757ddffe62f0bfd4" } 
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserName",
                keyValue: "Barba167"
            );
        }
    }
}
