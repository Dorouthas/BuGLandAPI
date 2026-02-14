using System.Text.Json.Serialization;

namespace BuGLandAPI.BuGLandAPI.DTOs.Requests;

public class PlayerDataRequest
{
    //获取玩家信息请求体
    [JsonPropertyName("username")]
    public string? UserName { get; set; } 
    
    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }
}