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
        
        //便捷方法: 获取玩家KD
        public (string normalKd, string fkKd) GetTotalKd(GameType gameTypeKey)
        {
                var gameData = GetGameData(gameTypeKey);
                if (gameData == null) return ("0.00", "0.00");
                int totalKills = 0;
                int totalDeaths = 0;
                int totalFinalKills = 0;
                int totalFinalDeaths = 0;
                foreach (var kvp in gameData)
                {
                        var stats = kvp.Value;
                        if (stats == null) continue;
                        totalKills += stats.Kills;
                        totalDeaths += stats.Deaths;
                        totalFinalKills += stats.FinalKills;
                        totalFinalDeaths += stats.FinalDeaths;
                }

                double normalKdValue = totalDeaths > 0 ? (double)totalKills / totalDeaths : totalKills;
                double fkKdValue =
                        totalFinalDeaths > 0
                                ? (double)totalFinalKills / totalFinalDeaths
                                : totalFinalKills; // 保留两位小数并返回字符串
                return (normalKdValue.ToString("F2"), fkKdValue.ToString("F2")); 
        }
        
        //便捷方法: 获取玩家对应游戏胜率
        public string GetTotalWinRate(GameType gameTypeKey)
        {
                var gameData = GetGameData(gameTypeKey);
                if (gameData == null) return "0.00%";
                int totalWin = 0;
                int totalGame = 0;
                foreach (var kvp in gameData)
                {
                        var stats = kvp.Value;
                        if (stats == null) continue;
                        totalWin += stats.Win;
                        totalGame += stats.Game;
                }

                double winRate = totalGame > 0 ? (double)totalWin / totalGame * 100 : 0;
                return $"{winRate:F2}%";
        }
        
        //便捷方法: 获取玩家总胜率
        public string GetWinRate()
        {
                double winRate = TotalGame > 0 ? (double)TotalWin / TotalGame * 100 : 0;
                return $"{winRate:F2}%";
        }
}