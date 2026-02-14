using System.Text.Json.Serialization;

namespace BuGLandAPI.BuGLandAPI.DTOs.Requests;

public class PlayerGameListRequest
{
    //获取玩家游戏对局列表请求体
    [JsonPropertyName("username")]
    public string? Username { get; set; }
    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; } 

    [JsonPropertyName("page")]
    public int Page { get; set; } = 1; 
}