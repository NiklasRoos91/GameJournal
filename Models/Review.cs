namespace GameJournal.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int GameId { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; }

        Game Game { get; set; }
    }
}
