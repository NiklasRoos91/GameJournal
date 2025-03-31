using Microsoft.AspNetCore.Mvc;
using GameJournal.Models;
using GameJournal.Services;
using GameJournal.Interfaces;
using GameJournal.DbContext;
using GameJournal.DTOs;
using Microsoft.Identity.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly GameJournalContext _context;
        private readonly IReviewService _reviewService;
        private readonly IGameService _gameService;

        public ReviewsController(GameJournalContext context, IReviewService reviewService, IGameService gameService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
            _gameService = gameService ?? throw new ArgumentNullException(nameof(gameService));
        }

        // POST api/<ReviewsController>
        [HttpPost("AddReview")]
        public IActionResult AddReview([FromBody] Review newReview)
        {
            if (newReview == null || string.IsNullOrWhiteSpace(newReview.Comment) || newReview.Grade < 1 || newReview.Grade > 5 )
            {
                return BadRequest("Invalid review data.");
            }

            _reviewService.AddReview(newReview);

            return Ok(newReview);            
        }

        // PUT api/<ReviewsController>/5
        [HttpPut("UpdateReview/{reviewId}")]
        public IActionResult UpdateReview(int reviewId, [FromBody] ReviewDto reviewDto)
        {
            if (reviewDto == null)
            {
                return BadRequest("Invalid review data.");
            }

            ReviewDto updatedReview = _reviewService.UpdateReview(reviewId, reviewDto);

            if (updatedReview == null)
            {
                return NotFound($"Review with ID {reviewId} not found.");
            }

            return Ok(updatedReview);
        }


        // GET api/<ReviewsController>/5
        [HttpGet("GetReviewByReviewId/{reviewId}")]
        public IActionResult GetReviewByReviewId(int reviewId)
        {
            ReviewDto review = _reviewService.GetReviewByReviewId(reviewId);

            if (review == null)
            {
                return NotFound($"Review with ID {reviewId} not found.");
            }

            return Ok(review);
        }

        // GET: api/<ReviewsController>
        [HttpGet("GetReviewByGameID/{gameId}")]
        public ActionResult<List<ReviewDto>> GetReviewsByGameID(int gameId)
        {

            List<ReviewDto> reviewDtos = _reviewService.GetReviewsByGameID(gameId);
            return Ok(reviewDtos);
        }

        // DELETE api/<ReviewsController>/5
        [HttpDelete("RemoveReviewByReviewId/{reviewId}")]
        public void RemoveReviewByReviewId(int reviewId)
        {

            _reviewService.RemoveReviewByReviewId(reviewId);
        }
           

        // DELETE api/<ReviewsController>/5
        [HttpDelete("RemoveReviewsByGameId/{gameId}")]
        public void RemoveReviewsByGameId(int gameId)
        {
            _reviewService.RemoveReviewsByGameId(gameId);
        }
    }
}
