using System.Text.Json.Serialization;

namespace BuGLandAPI.BuGLandAPI.DTOs.Requests;

public class LeaderboardDataRequest
{
    //获取排行榜数据请求体
    [JsonPropertyName("username")]
    public string? UserName { get; set; } 
    
    [JsonPropertyName("lb_type")]
    public string? LbType { get; set; } //排行榜标识 (如 solo_win_all_java)
}