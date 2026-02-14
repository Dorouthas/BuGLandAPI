using System.Text.Json;
using System.Text.Json.Serialization;
using BuGLandAPI.BuGLandAPI.Types;

namespace BuGLandAPI.BuGLandAPI.DTOs;

public class PlayerGameStateData
{
        
        [JsonPropertyName("_id")]
        public string Id { get; set; }//玩家id

        [JsonPropertyName("name")]
        public string Name { get; set; } //玩家名称

        //自动保留所有未知Key的Data，通过GetGameData获取指定的GameData
        [JsonExtensionData] 
        public Dictionary<string, JsonElement> ExtensionData { get; set; }
        
        public Dictionary<string, BedWarsModeStats?>? GetGameData(GameType gameTypeKey)
        { 
                Console.WriteLine(ExtensionData.Count);
                if (ExtensionData.TryGetValue(gameTypeKey.ToString().ToLower(), out JsonElement element))
                { 
                        return JsonSerializer.Deserialize<Dictionary<string, BedWarsModeStats>>(element.GetRawText());
                } 
                return null;
        }
        [JsonPropertyName("total_bed_destroy")]
        public int TotalBedDestroy { get; set; } 

        [JsonPropertyName("total_fk")]
        public int TotalFk { get; set; } 

        [JsonPropertyName("total_game")]
        public int TotalGame { get; set; } 

        [JsonPropertyName("total_win")]
        public int TotalWin { get; set; } 

        [JsonPropertyName("ttl")]
        public int Ttl { get; set; } 

        [JsonPropertyName("banned")]
        public bool Banned { get; set; } 
}