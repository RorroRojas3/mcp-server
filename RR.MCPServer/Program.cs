using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using RR.MCPServer.Repository;
using RR.MCPServer.Service;
using RR.MCPServer.Tool;

var builder = WebApplication.CreateBuilder(args);

// MSAL Authentication Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(options =>
    {
        builder.Configuration.Bind("AzureAd", options);

        // Explicitly validate audience to ensure token is for this API
        options.TokenValidationParameters.ValidateAudience = true;
        options.TokenValidationParameters.ValidAudiences =
        [
            builder.Configuration["AzureAd:ClientId"],
            $"api://{builder.Configuration["AzureAd:ClientId"]}"
        ];
    },
    options => builder.Configuration.Bind("AzureAd", options));

builder.Services.AddAuthorization();

// Database Configuration
builder.Services.AddDbContext<McpDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();

// Configure HttpClientFactory for DummyJSON API
var dummyJsonUrl = builder.Configuration.GetValue<string>("DummyJSON:Url") ?? string.Empty;
builder.Services.AddHttpClient("DummyJSON", client =>
{
    client.BaseAddress = new Uri(dummyJsonUrl);
});

// MCP Server Configuration
builder.Services
    .AddMcpServer()
    .WithToolsFromAssembly()
    .WithTools<DummyJsonTool>()
    .WithTools<DatabaseTool>()
    .WithHttpTransport();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Map MCP endpoints with authentication requirement
app.MapMcp().RequireAuthorization();

await app.RunAsync(); // Fixed: removed duplicate builder.Build()