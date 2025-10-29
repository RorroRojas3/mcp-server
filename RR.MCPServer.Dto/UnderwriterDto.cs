using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RR.MCPServer.Dto
{
    public class UnderwriterDto
    {
        public Guid Id { get; set; }

        [StringLength(128)]
        public string FirstName { get; set; } = null!;

        [StringLength(128)]
        public string LastName { get; set; } = null!;

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [StringLength(128)]
        public string Title { get; set; } = null!;
    }
}
