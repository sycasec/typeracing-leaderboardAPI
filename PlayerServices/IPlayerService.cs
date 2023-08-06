namespace typeRacingAPI.PlayerServices
{
    public interface IPlayerService
    {
        Task<SvcResponse<IEnumerable<Player>>> GetAllPlayers();
        Task<SvcResponse<Player?>> GetPlayerByID(int player_id);
        Task<SvcResponse<string>> UpdatePlayerByID(int player_id, Player pReq);
        Task<SvcResponse<string>> DeletePlayer(int player_id);
        Task<SvcResponse<string>> AddPlayer(Player pReq);
    }
}
