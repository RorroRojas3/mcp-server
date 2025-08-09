using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RR.MCPServer.Entity;

namespace RR.MCPServer.Repository.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            var dateTime = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            builder.HasData(
                new Test
                {
                    Id = new("d2ca3e40-dadd-44ba-8fcf-bbf92ec4ab3c"),
                    Name = "Test 1",
                    DateCreated = dateTime,
                },
                new Test
                {
                    Id = new("18dd538a-8c86-4e63-96aa-af4c6012b914"),
                    Name = "Test 2",
                    DateCreated = dateTime,
                }
            );
        }
    }
}
