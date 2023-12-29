using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class initmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "visimetric");

            migrationBuilder.CreateTable(
                name: "USERS",
                schema: "visimetric",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WOUNDS",
                schema: "visimetric",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(90)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOUNDS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WOUNDS_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "visimetric",
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MEASUREMENTS",
                schema: "visimetric",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WoundId = table.Column<string>(type: "varchar(90)", nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Area = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEASUREMENTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MEASUREMENTS_WOUNDS_WoundId",
                        column: x => x.WoundId,
                        principalSchema: "visimetric",
                        principalTable: "WOUNDS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MEASUREMENTS_WoundId",
                schema: "visimetric",
                table: "MEASUREMENTS",
                column: "WoundId");

            migrationBuilder.CreateIndex(
                name: "IX_WOUNDS_UserId",
                schema: "visimetric",
                table: "WOUNDS",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MEASUREMENTS",
                schema: "visimetric");

            migrationBuilder.DropTable(
                name: "WOUNDS",
                schema: "visimetric");

            migrationBuilder.DropTable(
                name: "USERS",
                schema: "visimetric");
        }
    }
}
