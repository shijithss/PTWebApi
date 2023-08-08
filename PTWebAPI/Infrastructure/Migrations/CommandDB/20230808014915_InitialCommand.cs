using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace User.Microservice.Infrastructure.Migrations.CommandDB
{
    public partial class InitialCommand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
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
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstName = table.Column<string>(type: "text", nullable: false),
                    lastName = table.Column<string>(type: "text", nullable: false),
                    maidenName = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    birthDate = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    bloodGroup = table.Column<string>(type: "text", nullable: false),
                    height = table.Column<int>(type: "integer", nullable: false),
                    weight = table.Column<double>(type: "double precision", nullable: false),
                    eyeColor = table.Column<string>(type: "text", nullable: false),
                    hair_color = table.Column<string>(type: "text", nullable: false),
                    hair_type = table.Column<string>(type: "text", nullable: false),
                    domain = table.Column<string>(type: "text", nullable: false),
                    ip = table.Column<string>(type: "text", nullable: false),
                    addressId = table.Column<int>(type: "integer", nullable: false),
                    macAddress = table.Column<string>(type: "text", nullable: false),
                    university = table.Column<string>(type: "text", nullable: false),
                    bank_cardExpire = table.Column<string>(type: "text", nullable: false),
                    bank_cardNumber = table.Column<string>(type: "text", nullable: false),
                    bank_cardType = table.Column<string>(type: "text", nullable: false),
                    bank_currency = table.Column<string>(type: "text", nullable: false),
                    bank_iban = table.Column<string>(type: "text", nullable: false),
                    company_addressId = table.Column<int>(type: "integer", nullable: false),
                    company_department = table.Column<string>(type: "text", nullable: false),
                    company_name = table.Column<string>(type: "text", nullable: false),
                    company_title = table.Column<string>(type: "text", nullable: false),
                    ein = table.Column<string>(type: "text", nullable: false),
                    ssn = table.Column<string>(type: "text", nullable: false),
                    userAgent = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Address_addressId",
                        column: x => x.addressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Address_company_addressId",
                        column: x => x.company_addressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    body = table.Column<string>(type: "text", nullable: false),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    tags = table.Column<List<string>>(type: "text[]", nullable: false),
                    reactions = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    todo = table.Column<string>(type: "text", nullable: false),
                    completed = table.Column<bool>(type: "boolean", nullable: false),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Todos_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_userId",
                table: "Posts",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_userId",
                table: "Todos",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_addressId",
                table: "Users",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_company_addressId",
                table: "Users",
                column: "company_addressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
