using Microsoft.EntityFrameworkCore;
using RR.MCPServer.Entity;
using RR.MCPServer.Repository.Configurations;

namespace RR.MCPServer.Repository
{
    public class PolicyDbContext(DbContextOptions<PolicyDbContext> options) : DbContext(options)
    {
        #region DbSets
        public DbSet<Policy> Policies { get; set; } = null!;

        public DbSet<Underwriter> Underwriters { get; set; } = null!;
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UnderwriterConfiguration());
            modelBuilder.ApplyConfiguration(new PolicyConfiguration());
        }
    }
}
