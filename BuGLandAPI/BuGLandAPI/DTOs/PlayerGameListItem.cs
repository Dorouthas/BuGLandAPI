using System.Text.Json.Serialization;
using BuGLandAPI.Converters;

namespace BuGLandAPI.BuGLandAPI.DTOs;

public class PlayerGameListItem(DateTime date, string type, bool win, string matchId)
{
    
    [JsonPropertyName("date")]
    [JsonConverter(typeof(DateFormatConverter))] 
    public DateTime Date { get; set; } = date;

    [JsonPropertyName(("type"))]
    public string Type { get; set; } = type;

    [JsonPropertyName(("win"))]
    public bool Win { get; set; } = win;

    [JsonPropertyName(("matchId"))]
    public string MatchId { get; set; } = matchId;
}