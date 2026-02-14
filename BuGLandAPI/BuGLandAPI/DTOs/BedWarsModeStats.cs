using System.Text.Json.Serialization;

namespace BuGLandAPI.BuGLandAPI.DTOs;

public class BedWarsModeStats(
    Dictionary<string, int> useItem,
    int bedDestroy,
    int game,
    Dictionary<string, int> upgrade,
    int finalKills,
    int lose,
    int bedLose,
    int win,
    int deaths,
    int deaths2,
    int finalDeaths,
    int kills)
{
    [JsonPropertyName("use_item")]
    public Dictionary<string, int> UseItem { get; set; } = useItem; //使用物品总数

    [JsonPropertyName("bed_destory")]
    public int BedDestroy { get; set; } = bedDestroy; //床破坏总数

    [JsonPropertyName("game")]
    public int Game { get; set; } = game; //游戏总数

    [JsonPropertyName("upgrade")]
    public Dictionary<string, int> Upgrade { get; set; } = upgrade; //升级次数

    [JsonPropertyName("final_kills")]
    public int FinalKills { get; set; } = finalKills; //最终击杀数

    [JsonPropertyName("lose")]
    public int Lose { get; set; } = lose; //败局总数

    [JsonPropertyName("bed_lose")]
    public int BedLose { get; set; } = bedLose; //床丢失总数

    [JsonPropertyName("win")]
    public int Win { get; set; } = win; //胜局总数

    [JsonPropertyName("deaths")]
    public int Deaths { get; set; } = deaths; //死亡总数

    [JsonPropertyName("deaths2")]
    public int Deaths2 { get; set; } = deaths2; //二次死亡总数

    [JsonPropertyName("final_deaths")]
    public int FinalDeaths { get; set; } = finalDeaths;//最终死亡总数

    [JsonPropertyName("kills")]
    public int Kills { get; set; } = kills;//总击杀数
}