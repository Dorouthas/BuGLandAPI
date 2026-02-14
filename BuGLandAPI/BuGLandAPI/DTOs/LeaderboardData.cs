using System.Text.Json.Serialization;

namespace BuGLandAPI.BuGLandAPI.DTOs;

public class LeaderboardData
{
    [JsonPropertyName("result")]
    public List<StatItem> Result { get; set; } = new();
        
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
        
    [JsonPropertyName("banned")]
    public bool Banned { get; set; }
    public class StatItem(int score, int top)
    {
        [JsonPropertyName("score")]
        public int Score { get; set; } = score; //对应的分数
        
        [JsonPropertyName("cn_type")]
        public string CnType { get; set; } = string.Empty; //对应类型
        
        [JsonPropertyName("top")]
        public int Top { get; set; } = top; // 具体名次
        
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty; // 具体类型
        
    }
}