using System.ComponentModel.DataAnnotations;

namespace RR.MCPServer.Dto
{
    public class PolicyDto
    {
        public Guid Id { get; set; }

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

        public Guid CarrierContactId { get; set; }

        public string CarrierContactEmail { get; set; } = null!;

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
    }
}
