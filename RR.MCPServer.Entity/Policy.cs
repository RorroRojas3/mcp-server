using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RR.MCPServer.Entity
{
    [Table(nameof(Policy), Schema = "Core")]
    public class Policy : BaseEntity
    {
        [StringLength(128)]
        public string PolicyNumber { get; set; } = null!;

        public DateOnly EffectiveDate { get; set; }

        public DateOnly ExpirationDate { get; set; }

        public DateOnly IssueDate { get; set; }

        [StringLength(128)]
        public string CertificateNumber { get; set; } = null!;

        [StringLength(128)]
        public string Carrier { get; set; } = null!;

        [StringLength(512)]
        public string CarrierAddress { get; set; } = null!;

        [ForeignKey(nameof(CarrierContact))]
        public Guid CarrierContactId { get; set; }

        [StringLength(128)]
        public string Producer { get; set; } = null!;

        [StringLength(512)]
        public string ProducerAddress { get; set; } = null!;

        [StringLength(128)]
        public string ProducerEmail { get; set; } = null!;

        [StringLength(128)]
        public string InsuredName { get; set; } = null!;

        [StringLength(512)]
        public string InsuredAddress { get; set; } = null!;

        [StringLength(128)]
        public string InsuredPhone { get; set; } = null!;

        public Underwriter CarrierContact { get; set; } = null!;
    }
}
