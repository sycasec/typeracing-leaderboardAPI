using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using typeRacingAPI.PlayerServices;

namespace typeRacingAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class PlayerController : ControllerBase {

        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService pSvc) {
            _playerService = pSvc;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetAllPlayers() => await _playerService.GetAllPlayers();

        [HttpPost]
        public async Task<ActionResult> AddPlayer(Player p) {
            var result = await _playerService.AddPlayer(p);
            if (result)
                return Ok($"Player {p.Name} successfully added.");
            return BadRequest($"Player {p} already exists!");
        }

        [HttpGet("{player_id}")]
        public async Task<ActionResult<Player>> GetPlayerByID(int player_id) {
            var player = await _playerService.GetPlayerByID(player_id);
            if (player == null)
                return BadRequest($"Player ID={player_id} does not exist!");
            return Ok(player);
        }

        [HttpPut("{player_id}")]
        public async Task<ActionResult> UpdatePlayerByID(int player_id, Player pReq) {
            var result = await _playerService.UpdatePlayerByID(player_id, pReq);
            if (result)
                return Ok($"Player {pReq.Name} successfully updated.");
            return BadRequest($"Player ID={player_id} does not exist!");
        }

        [HttpDelete("{player_id}")]
        public async Task<ActionResult> DeletePlayer(int player_id) {
            var result = await _playerService.DeletePlayer(player_id);
            if (result)
                return Ok($"Player ID={player_id} successfully deleted.");
            return BadRequest($"Player ID={player_id} does not exist!");
        }
    }
}