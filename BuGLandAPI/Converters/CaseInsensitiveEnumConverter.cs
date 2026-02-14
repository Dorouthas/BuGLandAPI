using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BuGLandAPI.Converters;

public class CaseInsensitiveEnumConverter<T> : JsonConverter<T> where T : struct, Enum
{
    //用来修复GameType的枚举中的JsonProprietyName不会被正常转换
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? enumString = reader.GetString();
        foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var attribute = field.GetCustomAttribute<JsonPropertyNameAttribute>();
            if (attribute != null && string.Equals(attribute.Name, enumString, StringComparison.OrdinalIgnoreCase))
                return (T)field.GetValue(null)!;
            if (string.Equals(field.Name, enumString, StringComparison.OrdinalIgnoreCase))
                return (T)field.GetValue(null)!;
        }
        throw new JsonException($"Cannot map '{enumString}' to enum {typeof(T).Name}.");
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        var field = typeof(T).GetField(value.ToString());
        var attribute = field?.GetCustomAttribute<JsonPropertyNameAttribute>();
        if (attribute != null)
        {
            writer.WriteStringValue(attribute.Name); 
        }
        else
        {

            writer.WriteStringValue(value.ToString().ToLowerInvariant());
        }
    }
}