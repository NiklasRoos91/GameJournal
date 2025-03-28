using GameJournal.DbContext;
using GameJournal.Services;
using Microsoft.EntityFrameworkCore;


namespace GameJournal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<GameJournalContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("GameJournalDatabase")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<GameService>();
            builder.Services.AddScoped<GameSeeder>();  // L�gg till GameSeeder till DI-container

            var app = builder.Build();

            // Skapa en scope f�r att anv�nda GameSeeder
            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<GameSeeder>();
                var games = seeder.GenerateGames(10);  // Skapa 10 slumpm�ssiga spel
                var context = scope.ServiceProvider.GetRequiredService<GameJournalContext>();  // H�mta GameJournalContext
                context.Games.AddRange(games);  // L�gg till genererade spel till databasen
                context.SaveChanges();  // Spara �ndringarna i databasen
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
