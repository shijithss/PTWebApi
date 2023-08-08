using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace User.Microservice.Infrastructure.Migrations.QueryDB
{
    public partial class updatequery2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Address_addressId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Address_company_addressId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.CreateTable(
                name: "AddressQuery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    coordinates_lat = table.Column<double>(type: "double precision", nullable: false),
                    coordinates_lng = table.Column<double>(type: "double precision", nullable: false),
                    postalCode = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressQuery", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AddressQuery_addressId",
                table: "Users",
                column: "addressId",
                principalTable: "AddressQuery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AddressQuery_company_addressId",
                table: "Users",
                column: "company_addressId",
                principalTable: "AddressQuery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AddressQuery_addressId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AddressQuery_company_addressId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AddressQuery");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coordinates_lat = table.Column<double>(type: "double precision", nullable: false),
                    coordinates_lng = table.Column<double>(type: "double precision", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    postalCode = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Address_addressId",
                table: "Users",
                column: "addressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Address_company_addressId",
                table: "Users",
                column: "company_addressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
