using System.Text.Json.Serialization;

namespace BuGLandAPI.BuGLandAPI.DTOs.Requests;

public class GuildDataRequset
{
    [JsonPropertyName("username")]
    public string? UserName { get; set; }  //玩家名称
    
    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; } //玩家UUID
    
    [JsonPropertyName("guild")]
    public string? GuildName { get; set; } //公会名称
}