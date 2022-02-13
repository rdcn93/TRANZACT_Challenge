using Microsoft.EntityFrameworkCore;
using TranzactChallenge.Infrastructure.Models;

namespace TranzactChallenge.Infrastructure.Data
{
    public class PremiumContext : DbContext
    {
        public PremiumContext()
        {
        }

        public PremiumContext(DbContextOptions<PremiumContext> options) : base(options)
        {
        }

        public DbSet<tb_premium> premiums { get; set; }
        public DbSet<tb_state> states { get; set; }
        public DbSet<tb_plan> plans { get; set; }
        public DbSet<tb_period> periods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PremiumContext).Assembly);
        }

    }
}
