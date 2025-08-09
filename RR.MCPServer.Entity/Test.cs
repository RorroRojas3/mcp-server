using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RR.MCPServer.Entity
{
    [Table(nameof(Test), Schema = "MCP")]
    public class Test : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; } = null!;
    }
}
