using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RR.MCPServer.Repository;
using RR.MCPServer.Service;
using RR.MCPServer.Tool;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services.AddDbContext<McpDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();

// Configure HttpClientFactory for weather.gov API
var dummyJsonUrl = builder.Configuration.GetValue<string>("DummyJSON:Url") ?? string.Empty;
builder.Services.AddHttpClient("DummyJSON", client =>
{
    client.BaseAddress = new Uri(dummyJsonUrl);
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly()
    .WithTools<DummyJsonTool>()
    .WithTools<DatabaseTool>();
await builder.Build().RunAsync();
