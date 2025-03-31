using GameJournal.DTOs;
using GameJournal.Models;

namespace GameJournal.Interfaces
{
    public interface IReviewService
    {
        void AddReview(Review review);
        void RemoveReviewByReviewId(int reviewId);
        void RemoveReviewsByGameId(int gameId);
        ReviewDto UpdateReview(int reviewId, ReviewDto reviewDto);
        ReviewDto GetReviewByReviewId(int reviewId);
        List<ReviewDto> GetReviewsByGameID(int gameId);
    }
}
