using System.ComponentModel;
using System.Text.Json.Serialization;

namespace BuGLandAPI.BuGLandAPI.Types;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SkywarsType
{
    /// <summary>
    /// 起床战争模式类型枚举
    /// </summary>

    /// <summary>
    /// 空岛战争单人模式
    /// </summary>
    [Description("solo")]
    SkyWarsSolo ,
    
    /// <summary>
    /// 空岛战争单人模式(无Kit)
    /// </summary>
    [Description("swrnokit")]
    SkyWarsNoKit,
    
    /// <summary>
    /// 空岛战争多人模式(无Kit)
    /// </summary>
    [Description("swrdouble")]
    SkyWarsDouble

}