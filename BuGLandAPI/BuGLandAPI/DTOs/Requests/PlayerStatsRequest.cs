using System.Text.Json.Serialization;
using BuGLandAPI.BuGLandAPI.Types;

namespace BuGLandAPI.BuGLandAPI.DTOs.Requests;

public class PlayerGameDataRequest
{
    //获取玩家指定游戏数据请求体
    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; } 
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("gametype")]
    public GameType GameType { get; set; }

    [JsonPropertyName("subtype")]
    public string SubType { get; set; } = "all";  // default: all | 2026,2025 and so on
}