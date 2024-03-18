using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calculator.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5835674a-c5af-43e7-9e1f-aee8208c83f5"), "Sum" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: new Guid("5835674a-c5af-43e7-9e1f-aee8208c83f5"));
        }
    }
}
