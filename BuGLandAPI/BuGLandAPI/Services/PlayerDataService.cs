using BuGLandAPI.BuGLandAPI.DTOs;
using BuGLandAPI.BuGLandAPI.DTOs.Requests;

namespace BuGLandAPI.BuGLandAPI.Services
{
    public class PlayerDataService(ApiClient apiClientBase)
    {
        //获取玩家信息
        public Task<ApiResponse<PlayerData>> GetPlayerDataAsync(PlayerDataRequest psDataRequest)
        {
            if (string.IsNullOrEmpty(psDataRequest.UserName) && string.IsNullOrEmpty(psDataRequest.Uuid))
            {
                throw new ArgumentException("必须提供 Username 或 Uuid");
            }
            return apiClientBase.PostAsync<PlayerData>("/player", psDataRequest);
        }
        //获取指定玩家的排行榜数据
        public Task<ApiResponse<LeaderboardData>> GetLeaderboardDataAsync(LeaderboardDataRequest psDataRequest)
        {
            if (string.IsNullOrEmpty(psDataRequest.UserName) && string.IsNullOrEmpty(psDataRequest.LbType))
            {
                throw new ArgumentException("必须提供 Username 或 排行榜标识");
            }
            return apiClientBase.PostAsync<LeaderboardData>("/leaderboard", psDataRequest);
        }
        //获取指定玩家的指定游戏数据
        public Task<ApiResponse<PlayerGameStateData>> GetPlayerGameDataAsync(PlayerGameDataRequest psRequest)
        {
            if (string.IsNullOrEmpty(psRequest.Username) && string.IsNullOrEmpty(psRequest.Uuid))
            {
                throw new ArgumentException("必须提供 Username 或 Uuid");
            }
            return apiClientBase.PostAsync<PlayerGameStateData>("/gamestats", psRequest);
        }
        //获取玩家对局列表
        public Task<ApiResponse<PlayerGameList>> GetPlayerGameListAsync(PlayerGameListRequest pglRequest)
        {
            if (string.IsNullOrEmpty(pglRequest.Username) && string.IsNullOrEmpty(pglRequest.Uuid))
            {
                throw new ArgumentException("必须提供 Username 或 Uuid");
            }
            return apiClientBase.PostAsync<PlayerGameList>("/gamelog/user", pglRequest);
        }
        //获取单个对局信息
        public Task<ApiResponse<PlayerGameList>> GetPlayerSingleMatchDataAsync(PlayerSingleMatchRequest psmRequest)
        {
            if (string.IsNullOrEmpty(psmRequest.Date.ToString()) && string.IsNullOrEmpty(psmRequest.MatchId))
            {
                throw new ArgumentException("必须提供 MatchId 和 Date");
            }
            return apiClientBase.PostAsync<PlayerGameList>("/gamelog/match", psmRequest);
        }
        
        //获取公会信息
        public Task<ApiResponse<GuildData>> GetGuildDataAsync(GuildDataRequset psDataRequset)
        {
            if (string.IsNullOrEmpty(psDataRequset.UserName) && string.IsNullOrEmpty(psDataRequset.Uuid) && string.IsNullOrEmpty(psDataRequset.GuildName))
            {
                throw new ArgumentException("必须提供 Username 或 Uuid 或 GuildName");
            }
            return apiClientBase.PostAsync<GuildData>("/guild", psDataRequset);
        }
        
        //获取2025年度总结
        public Task<ApiResponse<TotalData>> GetTotalDataAsync(TotalDataRequest psDataRequset)
        {
            if (string.IsNullOrEmpty(psDataRequset.Username) && string.IsNullOrEmpty(psDataRequset.Uuid))
            {
                throw new ArgumentException("必须提供 Username 或 Uuid");
            }
            return apiClientBase.PostAsync<TotalData>("/player/2025total", psDataRequset);
        }
    }
}
