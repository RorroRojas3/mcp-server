using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using RR.MCPServer.Dto;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Text.Json;

namespace RR.MCPServer.Service
{
    [McpServerToolType]
    public sealed class DummyJsonTool(ILogger<DummyJsonTool> logger, IHttpClientFactory httpClientFactory) 
    {
        private readonly ILogger<DummyJsonTool> _logger = logger;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly string _htttpClientName = "DummyJSON";

        [McpServerTool, Description("Get a recipe by its ID from the DummyJSON API.")]
        public async Task<string> GetRecipeByIdAsync([Description("The unique identifier of the recipe to retrieve")] int recipeId)
        {
            _logger.LogInformation("Fetching recipe with ID: {RecipeId}", recipeId);
            if (recipeId <= 0)
            {
                _logger.LogError("Invalid recipe ID: {RecipeId}", recipeId);
                throw new ArgumentException("Recipe ID must be greater than zero.", nameof(recipeId));
            }

            var client = _httpClientFactory.CreateClient(_htttpClientName);

            var result = await client.GetFromJsonAsync<RecipeDto>($"/recipes/{recipeId}");
            
            if (result == null)
            {
                _logger.LogWarning("No recipe found with ID: {RecipeId}", recipeId);
                return $"No recipe found with ID: {recipeId}";
            }

            return JsonSerializer.Serialize(result);
        }

        [McpServerTool, Description("Search for recipes by query from the DummyJSON API.")]
        public async Task<string> SearchRecipeAsync([Description("The search query to find recipes")] string query)
        {
            _logger.LogInformation("Searching recipes with query: {Query}", query);

            if (string.IsNullOrWhiteSpace(query))
            {
                _logger.LogError("Search query is null or empty");
                throw new ArgumentException("Search query cannot be null or empty.", nameof(query));
            }

            var client = _httpClientFactory.CreateClient(_htttpClientName);
            var result = await client.GetFromJsonAsync<RecipeSearchDto>($"/recipes/search?q={Uri.EscapeDataString(query)}");

            if (result == null || result.Recipes.Count == 0)
            {
                _logger.LogWarning("No recipes found for query: {Query}", query);
                return $"No recipes found for query: {query}";
            }

            return JsonSerializer.Serialize(result);
        }

        [McpServerTool, Description("Get a list of recipes from the DummyJSON API with optional pagination, field selection, and sorting.")]
        public async Task<string> GetRecipesAsync(
            [Description("Number of recipes to retrieve (use 0 to get all items)")] int limit = 10,
            [Description("Number of recipes to skip for pagination")] int skip = 0,
            [Description("Comma-separated list of fields to select (e.g., 'name,image')")] string? select = null,
            [Description("Field name to sort by")] string? sortBy = null,
            [Description("Sort order: 'asc' for ascending or 'desc' for descending")] string order = "asc")
        {
            _logger.LogInformation("Fetching recipes with limit: {Limit}, skip: {Skip}, select: {Select}, sortBy: {SortBy}, order: {Order}",
                limit, skip, select, sortBy, order);

            if (limit < 0 || skip < 0)
            {
                _logger.LogError("Invalid pagination parameters: limit={Limit}, skip={Skip}", limit, skip);
                throw new ArgumentException("Limit and skip must be non-negative.", nameof(limit));
            }

            if (!string.IsNullOrWhiteSpace(order) && order != "asc" && order != "desc")
            {
                _logger.LogError("Invalid order parameter: {Order}", order);
                throw new ArgumentException("Order must be 'asc' or 'desc'.", nameof(order));
            }

            var client = _httpClientFactory.CreateClient(_htttpClientName);

            var queryParams = new List<string>
            {
                $"limit={limit}",
                $"skip={skip}",
                $"order={order}"
            };

            if (!string.IsNullOrWhiteSpace(select))
            {
                queryParams.Add($"select={Uri.EscapeDataString(select)}");
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                queryParams.Add($"sortBy={Uri.EscapeDataString(sortBy)}");
            }

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
            var endpoint = $"/recipes{queryString}";

            var result = await client.GetFromJsonAsync<RecipeSearchDto>(endpoint);

            if (result == null)
            {
                _logger.LogWarning("No recipes found");
                return "No recipes found";
            }

            return JsonSerializer.Serialize(result);
        }
    }
}
