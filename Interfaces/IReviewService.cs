using GameJournal.DTOs;
using GameJournal.Models;

namespace GameJournal.Interfaces
{
    public interface IReviewService
    {
        void AddReview(Review review);
        void RemoveReview(int gameId);
        void UpdateReview(Review review);
        //List<ReviewDto> GetReviewByGame(string gameId);
    }
}
