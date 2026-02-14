using System.ComponentModel;
using System.Text.Json.Serialization;

namespace BuGLandAPI.BuGLandAPI.Types;
    /// <summary>
    /// 起床战争模式类型枚举
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum BedWarsType 
    {
        /// <summary>
        /// 起床战争 1v1 模式
        /// </summary>
        [Description("bw1")]
        BedWars1,

        /// <summary>
        /// 起床战争 2v2 模式
        /// </summary>
        [Description("bw8")]
        BedWars8,

        /// <summary>
        /// 起床战争 4v4 模式
        /// </summary>
        [Description("bw16")]
        BedWars16,

        /// <summary>
        /// 起床战争 8v8 xp模式
        /// </summary>
        [Description("bwxp32")]
        BedWarsXp32,

        /// <summary>
        /// 起床战争 16v16 xp模式
        /// </summary>
        [Description("bwxp64")]
        BedWarsXp64,

        /// <summary>
        /// 起床战争 4v4 xp模式
        /// </summary>
        [Description("bwxp8x4")]
        BedWarsXp8x4,

        /// <summary>
        /// 起床战争 无限模式
        /// </summary>
        [Description("bw999")]
        BedWars999
}