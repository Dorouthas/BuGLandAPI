using System.Text.Json;
using System.Text.Json.Serialization;
using BuGLandAPI.BuGLandAPI.Types;
using BuGLandAPI.Extensions;

namespace BuGLandAPI.BuGLandAPI.DTOs;

public class TotalData {
    
    [JsonPropertyName("uuid")] 
    public string Uuid { get; set; } = string.Empty; //玩家UUID
    
    [JsonPropertyName("basic")] 
    public BasicInfo Basic { get; set; } = new(); //玩家基础信息
    
    [JsonPropertyName("economy")]
    public Economy Economy { get; set; } = new(); //布吉岛信息
    
    [JsonPropertyName("combat")] 
    public Combat Combat { get; set; } = new(); //游戏信息
    
    [JsonPropertyName("social")]
    public Social Social { get; set; } = new(); //社交信息
}

public class BasicInfo
{
    [JsonPropertyName("reg_date")] 
    public long RegDate { get; set; } // 注册时间 对应 Unix Time(时间戳)
    
    [JsonPropertyName("latest_battle")] 
    public string LatestBattle { get; set; } = string.Empty;
    
    [JsonPropertyName("favorite_time")] 
    public FavoriteTime FavoriteTime { get; set; } = new(); // 最喜欢的时间段
    
    [JsonPropertyName("favorite_type")]
    public FavoriteType FavoriteType { get; set; } = new(); //最喜欢的游戏类型
}

public class FavoriteTime
{
    [JsonPropertyName("timePeriod")]
    public string TimePeriod { get; set; } = string.Empty; //时间段
    
    [JsonPropertyName("count")] 
    public int Count { get; set; } //对局数量
}

public class FavoriteType
{
    [JsonPropertyName("gameType")]
    public string GameType { get; set; } = string.Empty; //游戏类型
    
    [JsonPropertyName("count")]
    public int Count { get; set; } //对局数量
}

public class Economy
{
    [JsonPropertyName("bjdxp")] 
    public int Bjdxp { get; set; } //布吉岛经验值
    
    [JsonPropertyName("arcacoin")] 
    public int Arcacoin { get; set; } //街机硬币
    
    [JsonPropertyName("swcoin")]
    public int Swcoin { get; set; } //空岛战争硬币
    
    [JsonPropertyName("bwcoin")] 
    public int Bwcoin { get; set; } //起床战争硬币
}

public class Combat
{
    [JsonPropertyName("bedwars")]
    public Bedwars Bedwars { get; set; } = new(); //起床战争

    [JsonPropertyName("skywars")]
    public Skywars Skywars { get; set; } = new(); //空岛战争
}

public class Bedwars
{
    // API返回动态key对象（如 bw1/bw8/bw16）
    [JsonExtensionData]
    public Dictionary<string, JsonElement> RawModes { get; set; } = new(StringComparer.OrdinalIgnoreCase);

    [JsonIgnore]
    public Dictionary<BedWarsType, BwStats> Modes
    {
        get
        {
            var result = new Dictionary<BedWarsType, BwStats>();
            foreach (var type in Enum.GetValues<BedWarsType>())
            {
                result[type] = GetStats(type);
            }
            return result;
        }
    }

    public BwStats GetStats(BedWarsType type)
    {
        var key = type.GetDescription();
        if (RawModes.TryGetValue(key, out var raw))
        {
            return raw.Deserialize<BwStats>() ?? new BwStats();
        }

        // 兼容后端返回枚举名称作为key
        if (RawModes.TryGetValue(type.ToString(), out raw))
        {
            return raw.Deserialize<BwStats>() ?? new BwStats();
        }

        return new BwStats();
    }
}


public class BwStats
{
    [JsonPropertyName("bed_destory")]
    public int BedDestory { get; set; } //挖床数

    [JsonPropertyName("bed_lose")]
    public int BedLose { get; set; } //被挖床数

    [JsonPropertyName("deaths")]
    public int Deaths { get; set; } //死亡次数

    [JsonPropertyName("deaths2")]
    public int Deaths2 { get; set; } //死亡次数

    [JsonPropertyName("final_deaths")]
    public int FinalDeaths { get; set; } //最终死亡次数

    [JsonPropertyName("game")]
    public int Game { get; set; } //游戏次数

    [JsonPropertyName("kills")]
    public int Kills { get; set; } //击杀次数

    [JsonPropertyName("lose")]
    public int Lose { get; set; } //输的次数

    [JsonPropertyName("win")]
    public int Win { get; set; } //赢的次数

    [JsonPropertyName("final_kills")]
    public int FinalKills { get; set; } //最终击杀次数

    [JsonPropertyName("use_item")]
    public Dictionary<string,int> UseItem { get; set; } = new(); //使用物品信息

    [JsonPropertyName("upgrade")]
    public Dictionary<string,int> Upgrade { get; set; } = new(); //团队升级信息
}

public class Skywars
{
    // API返回动态key对象（如 solo/swrnokit/swrdouble）
    [JsonExtensionData]
    public Dictionary<string, JsonElement> RawModes { get; set; } = new(StringComparer.OrdinalIgnoreCase);

    [JsonIgnore]
    public Dictionary<SkywarsType, SwStats> Modes
    {
        get
        {
            var result = new Dictionary<SkywarsType, SwStats>();
            foreach (var type in Enum.GetValues<SkywarsType>())
            {
                result[type] = GetStats(type);
            }
            return result;
        }
    }

    public SwStats GetStats(SkywarsType type)
    {
        var key = type.GetDescription();
        if (RawModes.TryGetValue(key, out var raw))
        {
            return raw.Deserialize<SwStats>() ?? new SwStats();
        }

        // 兼容后端返回枚举名称作为key
        if (RawModes.TryGetValue(type.ToString(), out raw))
        {
            return raw.Deserialize<SwStats>() ?? new SwStats();
        }

        return new SwStats();
    }
}



public class SwStats
{
    [JsonPropertyName("deaths")]
    public int Deaths { get; set; } //死亡次数

    [JsonPropertyName("game")]
    public int Game { get; set; } //对局次数

    [JsonPropertyName("lose")]
    public int Lose { get; set; } //输的次数

    [JsonPropertyName("kills")]
    public int Kills { get; set; } //击杀次数

    [JsonPropertyName("win")]
    public int Win { get; set; } //赢的次数

    [JsonPropertyName("projectileKills")]
    public int ProjectileKills { get; set; } //投掷物击杀次数(包含弓)

    [JsonPropertyName("use_item")]
    public Dictionary<string,int> UseItem { get; set; } = new(); //使用物品次数
}

public class Social
{
    [JsonPropertyName("friends")]
    public List<string> Friends { get; set; } = new(); //朋友列表
}

