﻿// <auto-generated />
using System;
using CarRentalApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRentalApp.Migrations
{
    [DbContext(typeof(RentalModel))]
    partial class RentalModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarRentalApp.CustomerAccounts", b =>
                {
                    b.Property<int>("CustomerAccountNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CustomerAccountCreationDate");

                    b.Property<string>("CustomerAddress");

                    b.Property<string>("CustomerCreditCardNumber");

                    b.Property<string>("CustomerDriversLicenseNumber");

                    b.Property<string>("CustomerEmailAddress")
                        .HasMaxLength(50);

                    b.Property<string>("CustomerName");

                    b.Property<string>("CustomerPhoneNumber");

                    b.HasKey("CustomerAccountNumber")
                        .HasName("PK_Account");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CarRentalApp.RentalAgreement", b =>
                {
                    b.Property<int>("RentalID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerAccountsCustomerAccountNumber");

                    b.Property<DateTime>("DateOfPickup");

                    b.Property<DateTime>("DateOfReturn");

                    b.Property<string>("Destination");

                    b.Property<string>("Drivers");

                    b.Property<int>("LocationToDropOff");

                    b.Property<int>("LocationToPickup");

                    b.Property<string>("ReservationEmail");

                    b.HasKey("RentalID")
                        .HasName("PK_Agreements");

                    b.HasIndex("CustomerAccountsCustomerAccountNumber");

                    b.ToTable("RentalAgreement");
                });

            modelBuilder.Entity("CarRentalApp.RentalAgreement", b =>
                {
                    b.HasOne("CarRentalApp.CustomerAccounts")
                        .WithMany("RentalAgreement")
                        .HasForeignKey("CustomerAccountsCustomerAccountNumber");
                });
#pragma warning restore 612, 618
        }
    }
}