using System.Text.Json.Serialization;

namespace BuGLandAPI.BuGLandAPI.DTOs;

public class ApiResponse<T>(int code, string message, T data)
{
    //Api响应标准请求体结构
    [JsonPropertyName("code")]
    public int Code { get; set; } = code;

    [JsonPropertyName("message")]
    public string Message { get; set; } = message;

    [JsonPropertyName("data")]
    public T Data { get; set; } = data;


}
