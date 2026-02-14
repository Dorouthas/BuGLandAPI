using System.Text.Json.Serialization;

namespace BuGLandAPI.BuGLandAPI.DTOs;

public class GuildData
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty; // 公会数字 ID
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty; // 公会名称
    
    [JsonPropertyName("creator")]
    public string Creator { get; set; } = string.Empty; //公会创建者 ID
    
    [JsonPropertyName("owner")]
    public string Owner { get; set; } = string.Empty; //公会会长 ID (Maybe)
    
    [JsonPropertyName("broadcast")] 
    public List<string> Broadcast { get; set; } = new(); //广播 不知道是啥目前未做解析
    
    [JsonPropertyName("tag")]
    public string Tag { get; set; } = string.Empty; // 公会 Tag
    
    [JsonPropertyName("members")]
    public List<Member> Members { get; set; } = new(); //公会成员信息
    
    [JsonPropertyName("guildSetting")]
    public GuildSetting GuildSetting { get; set; } = new(); // 公会设置
    
    [JsonPropertyName("level")]
    public int Level { get; set; } //公会等级

    public class Member
    {
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; } = string.Empty; // 玩家 UUID
        
        [JsonPropertyName("online")]
        public bool Online { get; set; } // 玩家在线状态
        
        [JsonPropertyName("playerName")]
        public string PlayerName { get; set; } = string.Empty; //玩家名称
        
        [JsonPropertyName("role")]
        public string Role { get; set; } = string.Empty; //公会内玩家 等级(Rank)
    }
}

public class GuildSetting
{
    [JsonPropertyName("pointCount")]
    public string PointCount { get; set; } = string.Empty;
    
    [JsonPropertyName("maxMember")]
    public int MaxMember { get; set; } // 最大成员数
    
    [JsonPropertyName("INVITE_ONLY")]
    public bool Invite_Only { get; set; } //是否未邀请制
    
    [JsonPropertyName("TAG_EXPIRE")]
    public long Tag_Expire { get; set; } //公会Tag到期时间 对应时间未时间戳(Unix Time)
    
    [JsonPropertyName("DESC")]
    public string Desc { get; set; } = string.Empty; //公会描述
    
    [JsonPropertyName("status")]
    public int Status { get; set; }
}