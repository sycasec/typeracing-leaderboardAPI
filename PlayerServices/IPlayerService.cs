namespace typeRacingAPI.PlayerServices {
    public interface IPlayerService {
        Task<List<Player>> GetAllPlayers();
        Task<Player?> GetPlayerByID(int player_id);
        Task<bool> UpdatePlayerByID(int player_id, Player pReq);
        Task<bool> UpdatePlayerByName(string p_name, Player pReq);
        Task<bool> DeletePlayer(int player_id);
        Task<bool> AddPlayer(Player pReq);
    }
}