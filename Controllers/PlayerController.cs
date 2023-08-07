using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using typeRacingAPI.PlayerServices;

namespace typeRacingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PlayerController : ControllerBase
    {

        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService pSvc)
        {
            _playerService = pSvc;
        }

        [HttpGet]
        public async Task<ActionResult<SvcResponse<IEnumerable<Player>>>> GetAllPlayers() => await _playerService.GetAllPlayers();

        [HttpGet]
        public async Task<ActionResult<SvcResponse<IEnumerable<Player>>>> GetSortedPlayers() => await _playerService.GetSortedPlayers();

        [HttpPost]
        public async Task<ActionResult<SvcResponse<string>>> AddPlayer(Player p)
        {
            var result = await _playerService.AddPlayer(p);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("{player_id}")]
        public async Task<ActionResult<SvcResponse<Player>>> GetPlayerByID(int player_id)
        {
            var res = await _playerService.GetPlayerByID(player_id);
            if (res.Success)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpPut("{player_id}")]
        public async Task<ActionResult<SvcResponse<string>>> UpdatePlayerByID(int player_id, Player pReq)
        {
            var result = await _playerService.UpdatePlayerByID(player_id, pReq);
            if (result.Success)
                return Ok($"Player {pReq.Name} successfully updated.");
            return BadRequest($"Player ID={player_id} does not exist!");
        }

        [HttpDelete("{player_id}")]
        public async Task<ActionResult<SvcResponse<string>>> DeletePlayer(int player_id)
        {
            var result = await _playerService.DeletePlayer(player_id);
            if (result.Success)
                return Ok($"Player ID={player_id} successfully deleted.");
            return BadRequest($"Player ID={player_id} does not exist!");
        }
    }
}
