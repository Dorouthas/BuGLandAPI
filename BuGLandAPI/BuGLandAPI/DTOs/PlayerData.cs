using System.Text.Json.Serialization;

namespace BuGLandAPI.BuGLandAPI.DTOs;

public class PlayerData(
    string uuid,
    string swxpShow,
    string guildName,
    string bwxpShow,
    string playerName,
    string vipLevel,
    string bjdxpLevel)
{
    [JsonPropertyName("uuid")] 
    public string Uuid { get; set; } = uuid; //玩家 UUID
    
    [JsonPropertyName("swxp_show")]
    public string SwxpShow { get; set; } = swxpShow; //空岛战争 阶数,星数 
    
    [JsonPropertyName("guild_name")]
    public string GuildName { get; set; } = guildName; //公会名称
    
    [JsonPropertyName("bwxp_show")]
    public string BwxpShow { get; set; } = bwxpShow; //起床战争 阶数,星数 
    
    [JsonPropertyName("playername")]
    public string PlayerName { get; set; } = playerName; // 玩家名称
    
    [JsonPropertyName("vip_level")]
    public string VipLevel { get; set; } = vipLevel; // 玩家 VIP等级
    
    [JsonPropertyName("bjdxp_level")]
    public string BjdxpLevel { get; set; } = bjdxpLevel; // 布吉岛 大厅经验
}
