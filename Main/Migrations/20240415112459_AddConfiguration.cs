using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Main.Migrations
{
    /// <inheritdoc />
    public partial class AddConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "DocumentTypeId", "Label" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "Carte bleu" },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "Carte d'identité" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "Carte vitale" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "DocumentTypeId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "DocumentTypeId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "DocumentTypeId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));
        }
    }
}
