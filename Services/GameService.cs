using GameJournal.DbContext;
using GameJournal.DTOs;
using GameJournal.Models;
using static Bogus.DataSets.Name;

namespace GameJournal.Services
{
    public class GameService
    {
        private readonly GameJournalContext _context;

        public GameService(GameJournalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public void AddGame(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
        }

        public Game GetGameById(int id)
        {
            return _context.Games.FirstOrDefault(game => game.GameId == id);
        }

        public void RemoveGame(Game game)
        {
            _context.Games.Remove(game);
            _context.SaveChanges();
        }

        public List<GameDto> GetAllGames()
        {
            var games = _context.Games.ToList();

            var gameDtos = new List<GameDto>();

            foreach (var game in games)
            {
                var gameDto = new GameDto
                {
                    Title = game.Title,
                    Genre = game.Genre,
                    Status = game.Status,
                };
                gameDtos.Add(gameDto);
            }

            return gameDtos;
        }

        public List<GameDto> GetGamesByGenre(string genre)
        {
            List<Game> games = _context.Games.Where(game => game.Genre == genre).ToList();

            List<GameDto> gameDtos = new List<GameDto>();

            foreach (var game in games)
            {
                GameDto gameDto = new GameDto
                {
                    Title = game.Title,
                    Genre = game.Genre,
                    Status = game.Status,
                };
                gameDtos.Add(gameDto);
            }

            return gameDtos;
        }

        public List<GameDto> GetGamesByStatus(string status)
        {
            List<Game> games = _context.Games.Where(game => game.Status ==  status).ToList();

            List<GameDto> gameDtos = new List<GameDto>();

            foreach(var game in games)
            {
                GameDto gameDto = new GameDto
                {
                    Title = game.Title,
                    Genre = game.Genre,
                    Status = game.Status
                };
                gameDtos.Add(gameDto);
            }

            return gameDtos;
        }
    }
}
