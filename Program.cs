using GameJournal.DbContext;
using GameJournal.Services;
using GameJournal.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using GameJournal.Validators;



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

            // Registrerar alla validatorer automatiskt
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IGameService, GameService>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<GameSeeder>(); 
            builder.Services.AddScoped<ReviewSeeder>();
            builder.Services.AddScoped<DatabaseSeeder>();

            var app = builder.Build();

            // Skapa en scope för att köra seeder och fylla databasen
            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
                seeder.SeedDatabase();
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
