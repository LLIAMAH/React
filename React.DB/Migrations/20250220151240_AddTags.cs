using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace React.DB.Migrations
{
    /// <inheritdoc />
    public partial class AddTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Status_StatusId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "Statuses");

            migrationBuilder.AddColumn<long>(
                name: "TagId",
                table: "Projects",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TagId",
                table: "Projects",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Tags_TagId",
                table: "Projects",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Statuses_StatusId",
                table: "Tickets",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Tags_TagId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Statuses_StatusId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TagId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Status_StatusId",
                table: "Tickets",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
