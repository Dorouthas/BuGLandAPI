using System.Text.Json.Serialization;

namespace BuGLandAPI.BuGLandAPI.DTOs.Requests;

public class TotalDataRequest
{
    //获取玩家指定游戏数据请求体

    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; } 
    
    [JsonPropertyName("username")]
    public string? Username { get; set; }
}