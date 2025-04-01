using Microsoft.AspNetCore.Mvc;
using GameJournal.Models;
using GameJournal.Services;
using GameJournal.DbContext;
using GameJournal.DTOs;
using GameJournal.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly GameJournalContext _context;
        private readonly IReviewService _reviewService;

        public GamesController(IGameService gameService, GameJournalContext context, IReviewService reviewService)
        {
            _gameService = gameService ?? throw new ArgumentNullException(nameof(gameService));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
        }

        // GET: api/<GamesController>
        [HttpGet("GetAllGames")]
        public List<GameDto> GetAllGames()
        {
            List<GameDto> gameDtos = _gameService.GetAllGames();
            return gameDtos;
        }

        // GET api/<GamesController>/5
        [HttpGet("GetAllGamesByGenre/{genre}")]
        public ActionResult<List<GameDto>> GetGamesByGenre(string genre)
        {
            List<GameDto> gameDtos = _gameService.GetGamesByGenre(genre);
            return gameDtos;
        }

        // GET api/<GamesController>/6
        [HttpGet("GetAllGamesByStatus/{status}")]
        public ActionResult<List<GameDto>> GetGamesByStatus(string status)
        {
            List<GameDto> gameDtos = _gameService.GetGamesByStatus(status);
            return gameDtos;
        }

        // POST api/<GamesController>
        [HttpPost("AddGame")]
        public Game AddGame([FromBody] Game newGame)
        {
            if (newGame == null || string.IsNullOrWhiteSpace(newGame.Title) ||
                string.IsNullOrWhiteSpace(newGame.Genre) || string.IsNullOrWhiteSpace(newGame.Status))
            {
                return null;
            }

            _gameService.AddGame(newGame);
            return newGame;
        }

        // PUT api/<GamesController>/5
        [HttpPut("ChangeStatus/{gameId}")]
        public void ChangeStatus(int gameId, [FromBody] string status)
        {
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("RemoveGame/{gameId}")]
        public IActionResult DeleteGame(int gameId)
        {
            var game = _gameService.GetGameById(gameId);
            if (game == null)
            {
                return NotFound();
            }
            _reviewService.RemoveReviewsByGameId(game.GameId);

            _gameService.RemoveGame(game);
            return NoContent();
        }
    }
}
