using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using RR.MCPServer.Dto;
using RR.MCPServer.Repository;
using System.ComponentModel;
using System.Text.Json;

namespace RR.MCPServer.Tool
{
    [McpServerToolType]
    public sealed class PolicyTool(ILogger<PolicyTool> logger, PolicyDbContext ctx)
    {
        private readonly ILogger<PolicyTool> _logger = logger;
        private readonly PolicyDbContext _ctx = ctx;

        [McpServerTool, Description("Get a policy by id.")]
        public async Task<string> GetPolicyByIdAsync(
            [Description("The unique identifier of the policy to retrieve")] Guid id)
        {
            _logger.LogInformation("Fetching policy with ID: {id}", id);

            var policy = await _ctx.Policies
                            .Include(x => x.CarrierContact)
                            .Where(x => x.Id == id && !x.DateDeactivated.HasValue)
                            .Select(x => new PolicyDto
                            {
                                Id = x.Id,
                                PolicyNumber = x.PolicyNumber,
                                EffectiveDate = x.EffectiveDate,
                                ExpirationDate = x.ExpirationDate,
                                IssueDate = x.IssueDate,
                                CertificateNumber = x.CertificateNumber,
                                Carrier = x.Carrier,
                                CarrierAddress = x.CarrierAddress,
                                CarrierContactId = x.CarrierContactId,
                                CarrierContactEmail = x.CarrierContact.Email,
                                Producer = x.Producer,
                                ProducerAddress = x.ProducerAddress,
                                ProducerEmail = x.ProducerEmail,
                                InsuredName = x.InsuredName,
                                InsuredAddress = x.InsuredAddress,
                                InsuredPhone = x.InsuredPhone
                            })
                            .FirstOrDefaultAsync();
            if (policy == null)
            {
                _logger.LogInformation("No policy found with ID: {id}", id);
                return $"No policy found with ID: {id}";
            }

            return JsonSerializer.Serialize(policy);
        }

        [McpServerTool, Description("Get a list of policies from the database with optional filtering by carrier contact email, insured name, producer, policy number, certificate number and pagination support.")]
        public async Task<string> GetPoliciesAsync(
            [Description("Optional carrier contact email filter to search for policies containing this text")] string? carrierContactEmail = null,
            [Description("Optional insured name filter to search for policies containing this text")] string? insuredName = null,
            [Description("Optional producer filter to search for policies containing this text")] string? producer = null,
            [Description("Optional policy number filter to search for policies containing this text")] string? policyNumber = null,
            [Description("Optional certificate number filter to search for policies containing this text")] string? certificateNumber = null,
            [Description("Number of records to skip for pagination")] int skip = 0,
            [Description("Number of records to take for pagination")] int take = 10)
        {
            _logger.LogInformation("Fetching policies with carrierContactEmail filter: '{CarrierContactEmail}', insuredName filter: '{InsuredName}', producer filter: '{Producer}', policyNumber filter: '{PolicyNumber}', certificateNumber filter: '{CertificateNumber}', skip: {Skip}, take: {Take}",
                                carrierContactEmail, insuredName, producer, policyNumber, certificateNumber, skip, take);

            if (skip < 0 || take <= 0)
            {
                skip = 0;
                take = 10;  
            }

            var query = _ctx.Policies
                            .Include(x => x.CarrierContact)
                             .AsNoTracking()
                             .Where(x => !x.DateDeactivated.HasValue);

            // Apply carrier contact email filter if provided
            if (!string.IsNullOrWhiteSpace(carrierContactEmail))
            {     
                query = query.Where(x => EF.Functions.Like(x.CarrierContact.Email, $"%{carrierContactEmail}%"));
            }

            // Apply insured name filter if provided
            if (!string.IsNullOrWhiteSpace(insuredName))
            {
                query = query.Where(x => EF.Functions.Like(x.InsuredName, $"%{insuredName}%"));
            }

            // Apply producer filter if provided
            if (!string.IsNullOrWhiteSpace(producer))
            {
                query = query.Where(x => EF.Functions.Like(x.Producer, $"%{producer}%"));
            }

            // Apply policy number filter if provided
            if (!string.IsNullOrWhiteSpace(policyNumber))
            {
                query = query.Where(x => EF.Functions.Like(x.PolicyNumber, $"%{policyNumber}%"));
            }

            // Apply certificate number filter if provided
            if (!string.IsNullOrWhiteSpace(certificateNumber))
            {
                query = query.Where(x => EF.Functions.Like(x.CertificateNumber, $"%{certificateNumber}%"));
            }

            var results = await query
                            .OrderBy(x => x.PolicyNumber)
                            .Skip(skip)
                            .Take(take)
                            .Select(x => new PolicyDto
                            {
                                Id = x.Id,
                                PolicyNumber = x.PolicyNumber,
                                EffectiveDate = x.EffectiveDate,
                                ExpirationDate = x.ExpirationDate,
                                IssueDate = x.IssueDate,
                                CertificateNumber = x.CertificateNumber,
                                Carrier = x.Carrier,
                                CarrierAddress = x.CarrierAddress,
                                CarrierContactId = x.CarrierContactId,
                                CarrierContactEmail = x.CarrierContact.Email,
                                Producer = x.Producer,
                                ProducerAddress = x.ProducerAddress,
                                ProducerEmail = x.ProducerEmail,
                                InsuredName = x.InsuredName,
                                InsuredAddress = x.InsuredAddress,
                                InsuredPhone = x.InsuredPhone
                            }).ToListAsync();

            _logger.LogInformation("Found {Count} policies matching criteria", results.Count);
            return JsonSerializer.Serialize(results);
        }
    }
}
