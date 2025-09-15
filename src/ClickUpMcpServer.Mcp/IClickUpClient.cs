using ClickUpMcpServer.Models;
using Refit;

namespace ClickUpMcpServer;

internal interface IClickUpClient
{
    [Get("/team/{teamId}/space")]
    Task<IApiResponse<GetSpaces.Response>> GetSpacesAsync(string teamId);

    [Get("/space/{spaceId}/folder")]
    Task<IApiResponse<GetFolders.Response>> GetFoldersAsync(string spaceId, [Query] bool archived = false);

    [Get("/folder/{folderId}/list")]
    Task<IApiResponse<GetLists.Response>> GetListsAsync(string folderId, [Query] bool archived = false);

    [Get("/list/{listId}/task")]
    Task<IApiResponse<GetTasks.Response>> GetTasksAsync(string listId, [Query] int page = 0, [Query] bool archived = false, [Query] string[]? statuses = null, [Query] string[]? assignees = null, [Query] string[]? tags = null);
}   
