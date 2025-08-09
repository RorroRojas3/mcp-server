using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using RR.MCPServer.Repository;
using System.ComponentModel;
using System.Text.Json;

namespace RR.MCPServer.Tool
{
    /// <summary>
    /// Provides database access tools for retrieving test data through the Model Context Protocol (MCP) server.
    /// This tool class exposes methods for querying and retrieving test records from the database.
    /// </summary>
    [McpServerToolType]
    public sealed class DatabaseTool(ILogger<DatabaseTool> logger, McpDbContext ctx)
    {
        private readonly ILogger<DatabaseTool> _logger = logger;
        private readonly McpDbContext _ctx = ctx;

        /// <summary>
        /// Retrieves a specific test record from the database by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier (GUID) of the test record to retrieve.</param>
        /// <returns>
        /// A JSON-serialized string representation of the test record if found, 
        /// or a message indicating that no test was found with the specified ID.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the provided recipeId is an empty GUID.
        /// </exception>
        [McpServerTool, Description("Get a test by its ID from the database.")]
        public async Task<string> GetTestByIdAsync([Description("The unique identifier of the test to retrieve")] Guid id)
        {
            _logger.LogInformation("Fetching test with ID: {id}", id);

            if (id == Guid.Empty)
            {
                _logger.LogError("Invalid test ID: {id}", id);
                throw new ArgumentException("Test ID must be a valid GUID.", nameof(id));
            }

            var result = await _ctx.Tests.AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                _logger.LogWarning("No test found with ID: {id}", id);
                return $"No test found with ID: {id}";
            }

            return JsonSerializer.Serialize(result);
        }

        /// <summary>
        /// Retrieves a paginated list of test records from the database with optional name filtering.
        /// The results are ordered by name and support pagination through skip and take parameters.
        /// </summary>
        /// <param name="name">
        /// Optional filter to search for tests containing the specified text in their name. 
        /// If null or whitespace, no name filtering is applied.
        /// </param>
        /// <param name="skip">
        /// The number of records to skip for pagination. Must be non-negative. Defaults to 0.
        /// </param>
        /// <param name="take">
        /// The number of records to retrieve for pagination. Must be positive. Defaults to 10.
        /// </param>
        /// <returns>
        /// A JSON-serialized string representation of the list of test records that match the criteria.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when skip is negative or take is less than or equal to zero.
        /// </exception>
        [McpServerTool, Description("Get a list of tests from the database with optional filtering by name and pagination support.")]
        public async Task<string> GetTestsAsync(
            [Description("Optional name filter to search for tests containing this text")] string? name, 
            [Description("Number of records to skip for pagination")] int skip = 0, 
            [Description("Number of records to take for pagination")] int take = 10)
        {
            _logger.LogInformation("Fetching tests with name filter: '{Name}', skip: {Skip}, take: {Take}", name, skip, take);
            
            if (skip < 0 || take <= 0)
            {
                _logger.LogError("Invalid pagination parameters: skip={Skip}, take={Take}", skip, take);
                throw new ArgumentException("Skip must be non-negative and take must be positive.");
            }

            var query = _ctx.Tests.AsNoTracking();

            // Apply name filter if provided
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Name.Contains(name));
            }

            var results = await query
                        .OrderBy(x => x.Name)
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();

            _logger.LogInformation("Found {Count} tests matching criteria", results.Count);
            return JsonSerializer.Serialize(results);
        }
    }
}
