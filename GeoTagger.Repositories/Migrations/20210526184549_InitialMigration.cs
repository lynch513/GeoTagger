using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoTagger.Repositories.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Subtitle = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Address_Country = table.Column<string>(type: "text", nullable: true),
                    Address_State_Type_Name = table.Column<string>(type: "text", nullable: true),
                    Address_State_Type_Reduction = table.Column<string>(type: "text", nullable: true),
                    Address_State_Name = table.Column<string>(type: "text", nullable: true),
                    Address_State_Prefix = table.Column<bool>(type: "boolean", nullable: true),
                    Address_City_Type_Name = table.Column<string>(type: "text", nullable: true),
                    Address_City_Type_Reduction = table.Column<string>(type: "text", nullable: true),
                    Address_City_Name = table.Column<string>(type: "text", nullable: true),
                    Address_City_Prefix = table.Column<bool>(type: "boolean", nullable: true),
                    Address_Street_Type_Name = table.Column<string>(type: "text", nullable: true),
                    Address_Street_Type_Reduction = table.Column<string>(type: "text", nullable: true),
                    Address_Street_Name = table.Column<string>(type: "text", nullable: true),
                    Address_Street_Prefix = table.Column<bool>(type: "boolean", nullable: true),
                    Address_House_Type_Name = table.Column<string>(type: "text", nullable: true),
                    Address_House_Type_Reduction = table.Column<string>(type: "text", nullable: true),
                    Address_House_Name = table.Column<string>(type: "text", nullable: true),
                    Address_House_Prefix = table.Column<bool>(type: "boolean", nullable: true),
                    Address_Block_Type_Name = table.Column<string>(type: "text", nullable: true),
                    Address_Block_Type_Reduction = table.Column<string>(type: "text", nullable: true),
                    Address_Block_Name = table.Column<string>(type: "text", nullable: true),
                    Address_Block_Prefix = table.Column<bool>(type: "boolean", nullable: true),
                    Address_Room_Type_Name = table.Column<string>(type: "text", nullable: true),
                    Address_Room_Type_Reduction = table.Column<string>(type: "text", nullable: true),
                    Address_Room_Name = table.Column<string>(type: "text", nullable: true),
                    Address_Room_Prefix = table.Column<bool>(type: "boolean", nullable: true),
                    Coord_Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Coord_Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
