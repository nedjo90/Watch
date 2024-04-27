using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Main.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28aaa1dd-247b-4d4f-8683-76bf67383e0d", null, "Candidate", "CANDIDATE" },
                    { "3ae51554-d08d-4cf2-99f7-74b1aa4665ab", null, "Administrator", "ADMINISTRATOR" },
                    { "42d1964f-fa9a-4b10-86b0-875ea6baf080", null, "Moderator", "MODERATOR" },
                    { "5aff3191-4be5-498f-aad7-1085d2df9676", null, "Student", "STUDENT" },
                    { "a44c7a67-4b04-4600-a566-5af0f735d503", null, "Professor", "PROFESSOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28aaa1dd-247b-4d4f-8683-76bf67383e0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ae51554-d08d-4cf2-99f7-74b1aa4665ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42d1964f-fa9a-4b10-86b0-875ea6baf080");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5aff3191-4be5-498f-aad7-1085d2df9676");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a44c7a67-4b04-4600-a566-5af0f735d503");
        }
    }
}
