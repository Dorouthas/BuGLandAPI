using System.ComponentModel;
using System.Reflection;

namespace BuGLandAPI.Extensions;

public static class EnumExtensions
{
    /// <summary>
    /// 获取枚举的 Description 特性值，如果没有则返回枚举名称
    /// </summary>
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field!.GetCustomAttribute<DescriptionAttribute>();
        return attribute == null ? value.ToString() : attribute.Description;
    }
}