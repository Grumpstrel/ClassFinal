using Microsoft.EntityFrameworkCore;

namespace CarRentalApp
{
    public class RentalModel : DbContext
    {
        public virtual DbSet<CustomerAccounts> Accounts { get; set; }
        public virtual DbSet<RentalAgreement> Reservervation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RentalAccountDB;Integrated Security=True;Connect Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAccounts>(entity =>
            {
                entity.HasKey(e => e.CustomerAccountNumber)
                .HasName("PK_Account");

                entity.Property(e => e.CustomerAccountNumber)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.CustomerEmailAddress)
                .HasMaxLength(50);

                entity.HasMany(t => t.RentalAgreement);

                entity.ToTable("Accounts");
            });

            modelBuilder.Entity<RentalAgreement>(entity =>
            {
                entity.HasKey(e => e.RentalID)
                .HasName("PK_Agreements");

                entity.Property(e => e.RentalID)
                .ValueGeneratedOnAdd();

                //entity.HasOne(e => e.ReservationEmail);

                entity.ToTable("RentalAgreement");

            });

        }
    }
}



