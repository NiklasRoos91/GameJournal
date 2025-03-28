using Bogus;
using GameJournal.Models;
using Microsoft.EntityFrameworkCore;


namespace GameJournal.DbContext
{
    public class GameSeeder
    {

        public List<Game> GenerateGames(int numberOfGames)
        {
            // Skapa en instans av Faker för att generera slumpmässiga spel
            var faker = new Faker<Game>()
                .RuleFor(g => g.Title, f => f.Commerce.ProductName()) // Generera ett slumpmässigt spel namn
                .RuleFor(g => g.Genre, f => f.PickRandom("Action", "Adventure", "RPG", "Shooter", "Puzzle", "Strategy")) // Välj en genre
                .RuleFor(g => g.Status, f => f.PickRandom("Not Started", "In Progress", "Completed")); // Välj en status

            // Generera en lista med slumpmässiga spel
            var games = faker.Generate(numberOfGames);

            return games;
        }
    }
}
