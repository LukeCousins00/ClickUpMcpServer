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
    public async Task<string> ListClickUpFoldersAsync(string spaceId, bool archived = false)
    {
        var response = await clickUpClient.GetFoldersAsync(spaceId, archived);
        if (response.IsSuccessful)
        {
            var folders = response.Content!.folders;
            return JsonSerializer.Serialize(folders, JsonOptions);
        }

        return $"Error fetching folders: {response.StatusCode} - {response.Error.Content}";
    }

    [McpServerTool]
    [Description("Fetches the lists in a Folder")]
    public async Task<string> ListClickUpListsAsync(string folderId, bool archived = false)
    {
        var response = await clickUpClient.GetListsAsync(folderId, archived);
        if (response.IsSuccessful)
        {
            var lists = response.Content!.lists;
            return JsonSerializer.Serialize(lists, JsonOptions);
        }

        return $"Error fetching lists: {response.StatusCode} - {response.Error.Content}";
    }

    [McpServerTool]
    [Description("Fetches the tasks in a List with optional filters and paging")]
    public async Task<string> ListClickUpTasksAsync(string listId, int page = 0, bool archived = false, string[]? statuses = null, string[]? assignees = null, string[]? tags = null)
    {
        var response = await clickUpClient.GetTasksAsync(listId, page, archived, statuses, assignees, tags);
        if (response.IsSuccessful)
        {
            var tasks = response.Content!.tasks;
            // Include metadata like last_page as well
            var result = new { tasks, last_page = response.Content.last_page };
            return JsonSerializer.Serialize(result, JsonOptions);
        }

        return $"Error fetching tasks: {response.StatusCode} - {response.Error.Content}";
    }
}
