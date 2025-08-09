using System.Text.Json.Serialization;

namespace RR.MCPServer.Dto
{
    public class RecipeDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("ingredients")]
        public List<string> Ingredients { get; set; } = new();

        [JsonPropertyName("instructions")]
        public List<string> Instructions { get; set; } = new();

        [JsonPropertyName("prepTimeMinutes")]
        public int PrepTimeMinutes { get; set; }

        [JsonPropertyName("cookTimeMinutes")]
        public int CookTimeMinutes { get; set; }

        [JsonPropertyName("servings")]
        public int Servings { get; set; }

        [JsonPropertyName("difficulty")]
        public string Difficulty { get; set; } = string.Empty;

        [JsonPropertyName("cuisine")]
        public string Cuisine { get; set; } = string.Empty;

        [JsonPropertyName("caloriesPerServing")]
        public int CaloriesPerServing { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; } = new();

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; } = string.Empty;

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("reviewCount")]
        public int ReviewCount { get; set; }

        [JsonPropertyName("mealType")]
        public List<string> MealType { get; set; } = new();
    }
}
