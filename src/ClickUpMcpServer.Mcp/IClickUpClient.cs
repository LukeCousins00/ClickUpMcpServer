using ClickUpMcpServer.Models;
using Refit;

namespace ClickUpMcpServer;

internal interface IClickUpClient
{
    [Get("/team/{teamId}/space")]
    Task<IApiResponse<GetSpaces.Response>> GetSpacesAsync(string teamId);

    [Get("/space/{spaceId}/folder")]
    Task<IApiResponse<GetFolders.Response>> GetFoldersAsync(string spaceId);
}
