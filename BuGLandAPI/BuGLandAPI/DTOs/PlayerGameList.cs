using System.Text.Json.Serialization;

namespace BuGLandAPI.BuGLandAPI.DTOs;

public class PlayerGameList(int page, int pageSize, string? playerUuid, List<PlayerGameListItem>? data)
{
    [JsonPropertyName("page")] public int Page { get; set; } = page;

    [JsonPropertyName("pageSize")] public int PageSize { get; set; } = pageSize;

    [JsonPropertyName("playerUuid")] public string? PlayerUuid { get; set; } = playerUuid;

    [JsonPropertyName("data")] public List<PlayerGameListItem>? Data { get; set; } = data;
}