global using typeRacingAPI.Models;

namespace typeRacingAPI.PlayerServices {
    public class PlayerService : IPlayerService {

        private static List<Player> tempPlayerList = new List<Player>() {
            new Player { ID = 1, Name = "Kyle", Accuracy = 100.00f, Score = 100.00f, Timestamp = DateTime.Now},
            new Player { ID = 2, Name = "Not Kyle", Accuracy = 99.98f, Score = 69.96f, Timestamp = DateTime.Now.AddMinutes(-60)},
        };
        private readonly DataContext _context;
        public PlayerService(DataContext context){
            _context = context;
        }

        //TODO
        public async Task<SvcResponse<string>> AddPlayer(Player p) {
            var res = new SvcResponse<string>();
            var localPlayer = await _context.Players.FindAsync(p.ID);
            if (localPlayer != null) {
                res.Data = "Task Failed.";
                res.Success = false;
                res.Message = "Cannot reinsert an existing player with ID";
            } else {
                p.Timestamp = DateTime.UtcNow;
                _context.Players.Add(p);
                await _context.SaveChangesAsync();
                res.Data = "Task Success.";
                res.Message = $"Player {p.Name} successfully inserted into DB";
            }
            return res;
        }

        public async Task<SvcResponse<IEnumerable<Player>>> GetAllPlayers() {
            var dbPlayers = await _context.Players.ToListAsync();
            var res = new SvcResponse<IEnumerable<Player>> {
                Data = dbPlayers,
                Message = "200",
            };
            return res;
        }

        public async Task<SvcResponse<Player?>> GetPlayerByID(int player_id) {
            var player = await _context.Players.FindAsync(player_id);
            var res = new SvcResponse<Player?>();
            if (player == null) {
                res.Data = player;
                res.Message = $"Player with ID={player_id} does not exist!";
                res.Success = false;
            } else {
                res.Data = player;
                res.Message = "200";
            }
            return res;
        }

        public async Task<SvcResponse<string>> UpdatePlayerByID(int player_id, Player pReq) {
            var player = await _context.Players.FindAsync(player_id);
            var res = new SvcResponse<string>();
            if (player == null) {
                res.Data = "Task Failed.";
                res.Success = false;
                res.Message = $"Player with ID={player_id} does not exist";
            } else {
                player.Name = pReq.Name;
                player.Accuracy = pReq.Accuracy;
                player.Score = pReq.Score;
                player.Timestamp = DateTime.UtcNow;
                res.Data = "Task Success";
                await _context.SaveChangesAsync();
            }

            return res;
        }

        public async Task<SvcResponse<string>> DeletePlayer(int player_id) {
            var player = tempPlayerList.Find(p => p.ID == player_id);
            var res = new SvcResponse<string>();
            if (player is null) {
                res.Success = false;
                res.Message = $"Player with ID={player_id} does not exist";
                res.Data = "Task Failed.";
            } else {
                _context.Players.Remove(player);
                res.Data = "Task Success.";
                await _context.SaveChangesAsync();
            }
            return res;
        }
    }
}