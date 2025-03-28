using Microsoft.AspNetCore.Mvc;
using GameJournal.Models;
using GameJournal.Services;
using GameJournal.DbContext;
using GameJournal.DTOs;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameService _gameService;
        private readonly GameJournalContext _context;


        public GamesController(GameService gameService, GameJournalContext context)
        {
            _gameService = gameService;
            _context = context;
        }

        // GET: api/<GamesController>
        [HttpGet("GetAllGames")]
        public List<GameDto> GetAllGames()
        {
            List<GameDto> gameDtos = _gameService.GetAllGames();
            return gameDtos;
        }

        // GET api/<GamesController>/5
        [HttpGet("GetAllGamesByGenre{genre}")]
        public ActionResult<List<GameDto>> GetGamesByGenre(string genre)
        {
            List<GameDto> gameDtos = _gameService.GetGamesByGenre(genre);
            return gameDtos;
        }

        // GET api/<GamesController>/6
        [HttpGet("GetAllGamesByStatus{status}")]
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
        [HttpPut("ChangeStatus/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("RemoveGame/{id}")]
        public IActionResult DeleteGame(int id)
        {
            var game = _gameService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }

            _gameService.RemoveGame(game);
            return NoContent();
        }
    }
}
