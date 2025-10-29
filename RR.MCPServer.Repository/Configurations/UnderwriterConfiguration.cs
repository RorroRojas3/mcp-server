using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RR.MCPServer.Entity;

namespace RR.MCPServer.Repository.Configurations
{
    public class UnderwriterConfiguration : IEntityTypeConfiguration<Underwriter>
    {
        public void Configure(EntityTypeBuilder<Underwriter> builder)
        {
            var dateTime = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            builder.HasData(
                new Underwriter
                {
                    Id = new("d2ca3e40-dadd-44ba-8fcf-bbf92ec4ab3c"),
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john.smith@insurance.com",
                    Title = "Senior Underwriter",
                    DateCreated = dateTime,
                },
                new Underwriter
                {
                    Id = new("18dd538a-8c86-4e63-96aa-af4c6012b914"),
                    FirstName = "Sarah",
                    LastName = "Johnson",
                    Email = "sarah.johnson@insurance.com",
                    Title = "Lead Underwriter",
                    DateCreated = dateTime,
                },
                new Underwriter
                {
                    Id = new("a3b5c7d9-1234-5678-90ab-cdef12345678"),
                    FirstName = "Michael",
                    LastName = "Williams",
                    Email = "michael.williams@insurance.com",
                    Title = "Underwriter",
                    DateCreated = dateTime,
                },
                new Underwriter
                {
                    Id = new("b4c6d8e0-2345-6789-01bc-def123456789"),
                    FirstName = "Emily",
                    LastName = "Brown",
                    Email = "emily.brown@insurance.com",
                    Title = "Senior Underwriter",
                    DateCreated = dateTime,
                },
                new Underwriter
                {
                    Id = new("c5d7e9f1-3456-7890-12cd-ef1234567890"),
                    FirstName = "David",
                    LastName = "Davis",
                    Email = "david.davis@insurance.com",
                    Title = "Chief Underwriter",
                    DateCreated = dateTime,
                },
                new Underwriter
                {
                    Id = new("d6e8f0a2-4567-8901-23de-f12345678901"),
                    FirstName = "Jessica",
                    LastName = "Martinez",
                    Email = "jessica.martinez@insurance.com",
                    Title = "Underwriter",
                    DateCreated = dateTime,
                },
                new Underwriter
                {
                    Id = new("e7f9a1b3-5678-9012-34ef-123456789012"),
                    FirstName = "Robert",
                    LastName = "Garcia",
                    Email = "robert.garcia@insurance.com",
                    Title = "Senior Underwriter",
                    DateCreated = dateTime,
                },
                new Underwriter
                {
                    Id = new("f8a0b2c4-6789-0123-45f0-234567890123"),
                    FirstName = "Amanda",
                    LastName = "Rodriguez",
                    Email = "amanda.rodriguez@insurance.com",
                    Title = "Lead Underwriter",
                    DateCreated = dateTime,
                },
                new Underwriter
                {
                    Id = new("a9b1c3d5-7890-1234-5601-345678901234"),
                    FirstName = "Christopher",
                    LastName = "Wilson",
                    Email = "christopher.wilson@insurance.com",
                    Title = "Underwriter",
                    DateCreated = dateTime,
                },
                new Underwriter
                {
                    Id = new("b0c2d4e6-8901-2345-6712-456789012345"),
                    FirstName = "Jennifer",
                    LastName = "Taylor",
                    Email = "jennifer.taylor@insurance.com",
                    Title = "Senior Underwriter",
                    DateCreated = dateTime,
                }
            );
        }
    }
}
