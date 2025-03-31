using GameJournal.DTOs;
using GameJournal.Models;

namespace GameJournal.Interfaces
{
    public interface IGameService
    {
        void AddGame(Game game);
        Game GetGameById(int id);
        void RemoveGame(Game game);
        List<GameDto> GetAllGames();
        List<GameDto> GetGamesByGenre(string genre);
        List<GameDto> GetGamesByStatus(string status);

    }
}
