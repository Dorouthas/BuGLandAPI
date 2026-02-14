using System.Text;
using System.Text.Json;
using BuGLandAPI.Converters;
using BuGLandAPI.BuGLandAPI.DTOs;
using BuGLandAPI.BuGLandAPI.Types;

namespace BuGLandAPI.BuGLandAPI;

public class ApiClient
{
    private readonly string _apiUrl;
    private readonly string _token;
    private readonly HttpClient _httpClient;
    public readonly JsonSerializerOptions Options;

    public ApiClient(string apiUrl, string token)
    {
        this._apiUrl = apiUrl;
        this._token = token;
        this._httpClient = new HttpClient();        
        this.Options = new JsonSerializerOptions
        {
            WriteIndented = true, //允许换行（方便观察）
            PropertyNameCaseInsensitive = true ,
            Converters = { new CaseInsensitiveEnumConverter<GameType>() }   //用来修复GameType的枚举中的JsonProprietyName不会被正常转换(不要动www)
        };
    }
    // 保留返回string类型的类，仅用于泛型PostAsync调用和调试
    public async Task<string> PostRawAsync(string endpoint, string jsonBody)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _apiUrl + endpoint);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", "Bearer " + _token);
            request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result= await response.Content.ReadAsStringAsync();
           
            return result;
        }
        catch (HttpRequestException ex) when (ex.Message.Contains("400") || ex.Message.Contains("404"))
        {
            throw new Exception("请求参数错误或请求失败", ex);
        }
    }
    //仅用于调用和调试
    public string BuildRequestBody(object requestBody)
    {
        var jsonBody = JsonSerializer.Serialize(requestBody, Options);
        return jsonBody;
    }
    public async Task<ApiResponse<T>> PostAsync<T>(string endpoint, object requestBody)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _apiUrl + endpoint);
            var jsonBody = JsonSerializer.Serialize(requestBody, Options);
#if DEBUG
            Console.WriteLine($"JsonBody:{jsonBody}");
#endif
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", "Bearer " + _token);
            request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            if (responseJson == null)
            {
                throw new InvalidOperationException("API 访问数据失败,返回数据为空");
            }
            var result = JsonSerializer.Deserialize<ApiResponse<T>>(responseJson, Options);
            return result!;
        }
        catch (HttpRequestException ex) when (ex.Message.Contains("400") || ex.Message.Contains("404"))
        {
            throw new Exception("请求参数错误或请求失败", ex);
        }
    }
    
}