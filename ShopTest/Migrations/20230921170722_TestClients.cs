using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopTest.Migrations
{
    /// <inheritdoc />
    public partial class TestClients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "BirthDate", "LastName", "Name", "Patronimic", "RegistrationDate" },
                values: new object[,]
                {
                    { -3L, new DateTime(1975, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", "Alice", "Brown", new DateTime(2015, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -2L, new DateTime(1992, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", "Jane", "Johnson", new DateTime(2018, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -1L, new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", "John", "Smith", new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: -3L);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: -2L);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: -1L);
        }
    }
}
