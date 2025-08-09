using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using RR.MCPServer.Dto;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Text.Json;

namespace RR.MCPServer.Service
{
    public interface IDummyJsonService
    {
        Task<string> GetRecipeByIdAsync(int recipeId);
    }

    [McpServerToolType]
    public sealed class DummyJsonService(ILogger<DummyJsonService> logger, IHttpClientFactory httpClientFactory) : IDummyJsonService
    {
        private readonly ILogger<DummyJsonService> _logger = logger;
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
    }
}
