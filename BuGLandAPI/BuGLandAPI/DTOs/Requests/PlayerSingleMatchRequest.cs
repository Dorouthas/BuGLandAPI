using System.Text.Json.Serialization;
using BuGLandAPI.Converters;

namespace BuGLandAPI.BuGLandAPI.DTOs.Requests;

public class PlayerSingleMatchRequest
{
    //获取对局详情请求体
    [JsonPropertyName(("match"))]
    public string? MatchId { get; set; }
    [JsonPropertyName("date")]
    [JsonConverter(typeof(DateFormatConverter))]
    public DateTime? Date { get; set; }
}