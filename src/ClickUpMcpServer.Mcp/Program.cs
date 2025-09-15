using ClickUpMcpServer;
using ClickUpMcpServer.Tools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Refit;

var builder = Host.CreateApplicationBuilder(args);

// Configure all logs to go to stderr (stdout is used for the MCP protocol messages).
builder.Logging.AddConsole(o => o.LogToStandardErrorThreshold = LogLevel.Trace);

// Add the MCP services: the transport to use (stdio) and the tools to register.
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<ClickUpTools>();

builder.Services.AddRefitClient<IClickUpClient>()
    .ConfigureHttpClient(cfg =>
    {
        cfg.BaseAddress = new Uri("https://api.clickup.com/api/v2");
        cfg.DefaultRequestHeaders.Add("Authorization", Environment.GetEnvironmentVariable("PERSONAL_API_KEY"));
    });

await builder.Build().RunAsync();
