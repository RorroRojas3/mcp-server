using Microsoft.EntityFrameworkCore;
using RR.MCPServer.Entity;
using RR.MCPServer.Repository.Configurations;

namespace RR.MCPServer.Repository
{
    public class McpDbContext(DbContextOptions<McpDbContext> options) : DbContext(options)
    {
        #region DbSets
        public virtual DbSet<Test> Tests { get; set; } = null!;
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TestConfiguration());
        }
    }
}
