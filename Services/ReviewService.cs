using GameJournal.DbContext;
using GameJournal.DTOs;
using GameJournal.Interfaces;
using GameJournal.Models;

namespace GameJournal.Services
{
    public class ReviewService : IReviewService
    {
        private readonly GameJournalContext _context;

        public ReviewService(GameJournalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public ReviewDto UpdateReview(int reviewId, ReviewDto reviewDto)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.ReviewId == reviewId);

            if (review == null)
            {
                return null;
            }

            review.Grade = reviewDto.Grade;
            review.Comment = reviewDto.Comment;

            _context.SaveChanges();

            ReviewDto dto = new ReviewDto
            {
                GameId = review.GameId,
                Grade = review.Grade,
                Comment = review.Comment,
            };

            return dto;
        }

        public void RemoveReviewByReviewId(int reviewId)
        {
            Review reviewToRemove = _context.Reviews.FirstOrDefault(r => r.ReviewId == reviewId);

            _context.Reviews.Remove(reviewToRemove);
            _context.SaveChanges();
        }

        public void RemoveReviewsByGameId(int gameId)
        {
            var reviewsToRemove = _context.Reviews.Where(r => r.GameId == gameId).ToList();

            _context.RemoveRange(reviewsToRemove);
            _context.SaveChanges();
        }

        public ReviewDto GetReviewByReviewId(int reviewId)
        {
            Review review = _context.Reviews.FirstOrDefault(r =>r.ReviewId == reviewId);

            if (review == null)
            {
                return null;
            }

            ReviewDto dto = new ReviewDto
            {
                GameId = review.GameId,
                Grade = review.Grade,
                Comment = review.Comment
            };

            return dto;
        }

        public List<ReviewDto> GetReviewsByGameID(int gameId)
        {
            List<Review> reviews = _context.Reviews.Where(r =>r.GameId == gameId).ToList();

            List<ReviewDto> reviewDtos = new List<ReviewDto>();

            foreach (var review in reviews)
            {
                ReviewDto reviewDto = new ReviewDto
                {
                    GameId = review.GameId,
                    Grade = review.Grade,
                    Comment = review.Comment
                };
                reviewDtos.Add(reviewDto);
            }
            return reviewDtos;
        }
    }
}
