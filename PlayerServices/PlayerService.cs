global using typeRacingAPI.Models;

namespace typeRacingAPI.PlayerServices {
    public class PlayerService : IPlayerService {

        private static List<Player> tempPlayerList = new List<Player>() {
            new Player { ID = 1, Name = "Kyle", Accuracy = 100.00f, Score = 100.00f },
            new Player { ID = 2, Name = "Not Kyle", Accuracy = 99.98f, Score = 69.96f},
        };

        public async Task<bool> AddPlayer(Player p) {
            if (tempPlayerList.Contains(p))
                return false;
            tempPlayerList.Add(p);
            return true;
        }

        public async Task<List<Player>> GetAllPlayers() {
            return tempPlayerList;
        }

        public async Task<Player?> GetPlayerByID(int player_id) {
            var player = tempPlayerList.FirstOrDefault(p => p.ID == player_id);
            return player ?? null;
        }

        public async Task<bool> UpdatePlayerByID(int player_id, Player pReq) {
            var player = tempPlayerList.Find(p => p.ID == player_id);
            if (player == null)
                return false;
            player.Name = pReq.Name;
            player.Accuracy = pReq.Accuracy;
            player.Score = pReq.Score;
            return true;
        }

        public async Task<bool> UpdatePlayerByName(string p_name, Player pReq) {
            var player = tempPlayerList.Find(p => p.Name == p_name);
            if (player == null)
                return false;
            player.Name = pReq.Name;
            player.Accuracy = pReq.Accuracy;
            player.Score = pReq.Score;
            return true;
        }

        public async Task<bool> DeletePlayer(int player_id) {
            var player = tempPlayerList.Find(p => p.ID == player_id);
            if (player is null)
                return false;
            tempPlayerList.Remove(player);
            return true;
        }
    }
}