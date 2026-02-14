using System.Text.Json.Serialization;

namespace BuGLandAPI.BuGLandAPI.Types;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GameType
{
    // 起床战争
    [JsonPropertyName("bedwars")]
    Bedwars,
    
    // 空岛战争
    [JsonPropertyName("skywars")]
    Skywars,
    
    // 村庄防御
    [JsonPropertyName("vdefense")]
    VDefense,
    
    // 竞技场PVP
    [JsonPropertyName("arenapvp")]
    ArenaPvP,
 
    // 暗区
    [JsonPropertyName("anqu")]
    AnQu,
    
    //  kits 战斗
    [JsonPropertyName("kitbattle")]
    KitBattle,
   
    // anni ?
    [JsonPropertyName("anni")]
    Anni,
    
    // 成就
    [JsonPropertyName("achievement")]
    Achievement
}