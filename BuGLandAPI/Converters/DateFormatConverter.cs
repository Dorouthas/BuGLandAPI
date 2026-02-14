using System.Text.Json;
using System.Text.Json.Serialization;

namespace BuGLandAPI.Converters;

public class DateFormatConverter : JsonConverter<DateTime>
{
    private const string DateFormat = "yyyy-MM-dd HH:mm:ss";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // 读取字符串并解析为 DateTime
        return DateTime.ParseExact(reader.GetString() ?? string.Empty, DateFormat, null);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        // 序列化时写入指定格式
        writer.WriteStringValue(value.ToString(DateFormat));
    }
}