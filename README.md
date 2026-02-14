# BuGLandAPI

`BuGLandAPI` 是一个基于 `.NET 9` 的 C# API 封装库，用于访问布吉岛（Heypixel）相关玩家与对局数据接口。  

## 目录

- [功能特性](#功能特性)
- [项目结构](#项目结构)
- [环境要求](#环境要求)
- [快速开始](#快速开始)
- [使用示例](#使用示例)
- [动态年度总结示例](#动态年度总结示例)
- [API 文档](#api-文档)
- [已封装接口](#已封装接口)
- [注意事项](#注意事项)
- [贡献指南](#贡献指南)
- [许可证](#许可证)
- [特别鸣谢](#特别鸣谢)

## 功能特性

- 统一 `ApiClient`，内置 Bearer Token 鉴权
- `PlayerDataService` 聚合常用业务接口
- 类型化 DTO 与统一响应模型 `ApiResponse<T>`
- 内置枚举与日期转换器，提升序列化兼容性

## 项目结构

```text
.
├─ BuGLandAPI.sln
├─ global.json
├─ README.md
└─ BuGLandAPI/
   ├─ BuGLandAPI.csproj
   ├─ Converters/
   ├─ Extensions/
   └─ BuGLandAPI/
      ├─ ApiClient.cs
      ├─ Services/
      ├─ DTOs/
      └─ Types/
```

## 环境要求

- `.NET SDK 9.0.x`

## 快速开始

```bash
dotnet restore "./BuGLandAPI.sln"
dotnet build "./BuGLandAPI.sln" -v minimal
```

## 使用示例

```csharp
using BuGLandAPI.BuGLandAPI;
using BuGLandAPI.BuGLandAPI.DTOs.Requests;
using BuGLandAPI.BuGLandAPI.Services;

var client = new ApiClient("https://api.mcbjd.net/v2", "your-token");
var service = new PlayerDataService(client);

var response = await service.GetPlayerDataAsync(new PlayerDataRequest
{
    UserName = "Steve"
});

if (response.Code == 0)
{
    Console.WriteLine($"玩家名: {response.Data.PlayerName}");
}
else
{
    Console.WriteLine($"请求失败: {response.Message}");
}
```

## 动态年度总结示例

```csharp
using BuGLandAPI.BuGLandAPI;
using BuGLandAPI.BuGLandAPI.DTOs.Requests;
using BuGLandAPI.BuGLandAPI.Services;

var client = new ApiClient("https://api.mcbjd.net/v2", "your-token");
var service = new PlayerDataService(client);

var response = await service.GetTotalDataAsync(
    new TotalDataRequest { Username = "Steve" }
);

if (response.Code == 0)
{
    Console.WriteLine($"大厅经验: {response.Data.Economy.Bjdxp}");
    var soloStats = response.Data.Combat.Bedwars.GetStats(BedWarsType.BedWars8);
    Console.WriteLine($"胜利局数: {soloStats.Win}");
}
else
{
    Console.WriteLine($"请求失败: {response.Message}");
}
```

## API 文档

- 官方文档：https://mcbjd.net/docs/api/bugland-api

## 已封装接口

`PlayerDataService` 当前提供以下方法（含 endpoint 与参数示例）：

### 1.GetPlayerDataAsync(PlayerDataRequest)

- Endpoint: `POST /player`
- 参数示例：

```json
{
  "username": "Steve"
}
```

### 2.GetLeaderboardDataAsync(LeaderboardDataRequest)

- Endpoint: `POST /leaderboard`
- 参数示例：

```json
{
  "username": "Steve",
  "lb_type": "solo_win_all_java"
}
```

### 3.GetPlayerGameDataAsync(PlayerGameDataRequest)

- Endpoint: `POST /gamestats`
- 参数示例：

```json
{
  "username": "Steve",
  "gametype": "bedwars",
  "subtype": "all"
}
```

### 4.GetPlayerGameListAsync(PlayerGameListRequest)

- Endpoint: `POST /gamelog/user`
- 参数示例：

```json
{
  "username": "Steve",
  "page": 1
}
```

### 5.GetPlayerSingleMatchDataAsync(PlayerSingleMatchRequest)

- Endpoint: `POST /gamelog/match`
- 参数示例：

```json
{
  "match": "match_id_example",
  "date": "2026-01-01 12:00:00"
}
```

### 6.GetGuildDataAsync(GuildDataRequset)

- Endpoint: `POST /guild`
- 参数示例：

```json
{
  "guild": "BuGLand"
}
```

### 7.GetTotalDataByYearAsync(TotalDataRequest, int year)

- Endpoint: `POST /player/{year}total`
- 参数示例（`year` 为路径参数）：

```json
{
  "username": "Steve"
}
```

### 8.GetTotalDataAsync(TotalDataRequest)

- Endpoint: `POST /player/2025total`
- 参数示例：

```json
{
  "username": "Steve"
}
```

## 注意事项

- `PlayerSingleMatchRequest.Date` 序列化格式：`yyyy-MM-dd HH:mm:ss`

## 贡献指南

欢迎通过 Issue / Pull Request 参与改进，提交前请阅读 `CONTRIBUTING.md`。

## 许可证

本项目使用 `MIT License`，详见 `LICENSE`。

## 特别鸣谢


**布吉岛 Team(提供API及文档支持)** 
**OpenAI(BUG修复及Readme编写)**。  
学习参考项目：https://github.com/LangYa466/BJDAPI。
