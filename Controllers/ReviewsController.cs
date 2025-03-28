using Microsoft.AspNetCore.Mvc;
using GameJournal.Models;
using GameJournal.Services;
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
        private readonly GameJournalContext _gameJournalContext;
        private readonly ReviewService _reviewService;

        public ReviewsController(GameJournalContext gameJournalContext, ReviewService reviewService)
        {
            _gameJournalContext = gameJournalContext;
            _reviewService = reviewService;
        }

        // GET: api/<ReviewsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ReviewsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReviewsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReviewsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReviewsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
