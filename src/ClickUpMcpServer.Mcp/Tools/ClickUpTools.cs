using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace ClickUpMcpServer.Tools;

[McpServerToolType]
internal class ClickUpTools(IClickUpClient clickUpClient)
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

    [McpServerTool]
    [Description("Fetches the list of Spaces.")]
    public async Task<string> ListClickUpSpacesAsync()
    {
        var teamId = Environment.GetEnvironmentVariable("TEAM_ID")!;

        var response = await clickUpClient.GetSpacesAsync(teamId);
        if (response.IsSuccessful)
        {
            var spaces = response.Content!.spaces;
            return JsonSerializer.Serialize(spaces, JsonOptions);
        }

        return $"Error fetching spaces: {response.StatusCode} - {response.Error.Content}";
    }

    [McpServerTool]
    [Description("Fetches the list of Folders in a Space")]
    public async Task<string> ListClickUpFoldersAsync(string spaceId)
    {
        var response = await clickUpClient.GetFoldersAsync(spaceId);
        if (response.IsSuccessful)
        {
            var folders = response.Content!.folders;
            return JsonSerializer.Serialize(folders, JsonOptions);
        }

        return $"Error fetching folders: {response.StatusCode} - {response.Error.Content}";
    }
}
