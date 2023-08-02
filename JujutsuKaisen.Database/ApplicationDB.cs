using JujutsuKaisen.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace JujutsuKaisen.Database
{
    public class ApplicationDB : DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options)
        {
        }

        public DbSet<Characters> Characters { get; set; } = null!;
        public DbSet<Clan> Clan { get; set; } = null!;
    }
}