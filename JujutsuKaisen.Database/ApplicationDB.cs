using JujutsuKaisen.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace JujutsuKaisen.Database
{
    public class ApplicationDB : DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Characters>(entity =>
            {
                entity.HasKey(e => e.IdCharacter);
                entity.Property(e => e.IdCharacter).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.Age).IsRequired();
                entity.Property(e => e.Image).IsRequired();
                entity.HasOne(e => e.Clan).WithMany(e => e.Characters).HasForeignKey(e => e.IdClan);
            });

            modelBuilder.Entity<Clan>(entity =>
            {
                entity.HasKey(e => e.IdClan);
                entity.Property(e => e.IdClan).ValueGeneratedOnAdd();
                entity.ToTable("Clan");
                entity.Property(e => e.ClanName).IsRequired();
                entity.Property(e => e.Image).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Characters> Characters { get; set; } = null!;
        public DbSet<Clan> Clan { get; set; } = null!;
    }
}