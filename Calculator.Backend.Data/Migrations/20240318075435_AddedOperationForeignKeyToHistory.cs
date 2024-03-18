using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calculator.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedOperationForeignKeyToHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OperationUuid",
                table: "Histories",
                newName: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_OperationId",
                table: "Histories",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Operations_OperationId",
                table: "Histories",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Operations_OperationId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_OperationId",
                table: "Histories");

            migrationBuilder.RenameColumn(
                name: "OperationId",
                table: "Histories",
                newName: "OperationUuid");
        }
    }
}
