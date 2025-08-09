using RR.MCPServer.Dto;
using System.Text.Json.Serialization;

public class RecipeSearchDto
{
    [JsonPropertyName("recipes")]
    public List<RecipeDto> Recipes { get; set; } = new();

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("skip")]
    public int Skip { get; set; }

    [JsonPropertyName("limit")]
    public int Limit { get; set; }
}