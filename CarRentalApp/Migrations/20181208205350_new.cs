using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalApp.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerAddress = table.Column<string>(nullable: true),
                    CustomerPhoneNumber = table.Column<string>(nullable: true),
                    CustomerEmailAddress = table.Column<string>(maxLength: 50, nullable: true),
                    CustomerDriversLicenseNumber = table.Column<string>(nullable: true),
                    CustomerCreditCardNumber = table.Column<string>(nullable: true),
                    CustomerAccountNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerAccountCreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.CustomerAccountNumber);
                });

            migrationBuilder.CreateTable(
                name: "RentalAgreement",
                columns: table => new
                {
                    RentalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReservationEmail = table.Column<string>(nullable: true),
                    DateOfPickup = table.Column<DateTime>(nullable: false),
                    LocationToPickup = table.Column<int>(nullable: false),
                    DateOfReturn = table.Column<DateTime>(nullable: false),
                    LocationToDropOff = table.Column<int>(nullable: false),
                    Destination = table.Column<string>(nullable: true),
                    Drivers = table.Column<string>(nullable: true),
                    CustomerAccountsCustomerAccountNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.RentalID);
                    table.ForeignKey(
                        name: "FK_RentalAgreement_Accounts_CustomerAccountsCustomerAccountNumber",
                        column: x => x.CustomerAccountsCustomerAccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "CustomerAccountNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalAgreement_CustomerAccountsCustomerAccountNumber",
                table: "RentalAgreement",
                column: "CustomerAccountsCustomerAccountNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalAgreement");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
