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
    public sealed class UnderwriterTool(ILogger<UnderwriterTool> logger, PolicyDbContext ctx)
    {
        private readonly ILogger<UnderwriterTool> _logger = logger;
        private readonly PolicyDbContext _ctx = ctx;

        [McpServerTool, Description("Gets an underwriter by id.")]
        public async Task<string> GetUnderwriterByIdAsync(
            [Description("The unique identifier of the underwriter to retrieve")] Guid id)
        {
            _logger.LogInformation("Fetching underwriter with ID: {Id}", id);

            var dto = await _ctx.Underwriters
                .Where(x => x.Id == id && !x.DateDeactivated.HasValue)
                .Select(x => new UnderwriterDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Title = x.Title
                })
                .FirstOrDefaultAsync();

            if (dto == null)
            {
                _logger.LogInformation("No underwriter found with ID: {Id}", id);
                return $"No underwriter found with ID: {id}";
            }

            return JsonSerializer.Serialize(dto);
        }

        [McpServerTool, Description("Get a list of underwriters from the database with optional filtering by first name, last name, email, title and pagination support.")]
        public async Task<string> GetUnderwritersAsync(
            [Description("Optional first name filter to search for underwriters containing this text")] string? firstName = null,
            [Description("Optional last name filter to search for underwriters containing this text")] string? lastName = null,
            [Description("Optional email filter to search for underwriters containing this text")] string? email = null,
            [Description("Optional title filter to search for underwriters containing this text")] string? title = null,
            [Description("Number of records to skip for pagination")] int skip = 0,
            [Description("Number of records to take for pagination")] int take = 10)
        {
            _logger.LogInformation("Fetching underwriters with firstName filter: '{FirstName}', lastName filter: '{LastName}', email filter: '{Email}', title filter: '{Title}', skip: {Skip}, take: {Take}",
                firstName, lastName, email, title, skip, take);

            if (skip < 0 || take <= 0)
            {
                _logger.LogError("Invalid pagination parameters: skip={Skip}, take={Take}", skip, take);
                throw new ArgumentException("Skip must be non-negative and take must be positive.");
            }

            var query = _ctx.Underwriters
                .AsNoTracking()
                .Where(x => !x.DateDeactivated.HasValue);

            // Apply first name filter if provided
            if (!string.IsNullOrWhiteSpace(firstName))
            {
                query = query.Where(x => EF.Functions.Like(x.FirstName, $"%{firstName}%"));
            }

            // Apply last name filter if provided
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                query = query.Where(x => EF.Functions.Like(x.LastName, $"%{lastName}%"));
            }

            // Apply email filter if provided
            if (!string.IsNullOrWhiteSpace(email))
            {
                query = query.Where(x => EF.Functions.Like(x.Email, $"%{email}%"));
            }

            // Apply title filter if provided
            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(x => EF.Functions.Like(x.Title, $"%{title}%"));
            }

            var results = await query
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Skip(skip)
                .Take(take)
                .Select(x => new UnderwriterDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Title = x.Title
                })
                .ToListAsync();

            _logger.LogInformation("Found {Count} underwriters matching criteria", results.Count);
            return JsonSerializer.Serialize(results);
        }
    }
}
