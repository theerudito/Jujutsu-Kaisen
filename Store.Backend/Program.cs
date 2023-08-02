using Microsoft.EntityFrameworkCore;
using Store.Database;
using Store.Repository.Backend;
using Store.Repository.Service;

var builder = WebApplication.CreateBuilder(args);

// cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICharacters, CharacterRepositoryBackend>();
builder.Services.AddScoped<IClan, ClanRepositoryBackend>();

//var connectionString = builder.Configuration.GetConnectionString("MySqlite");
//builder.Services.AddDbContext<ApplicationDB>(options => options.UseSqlite(connectionString));

string baseDirectory = AppContext.BaseDirectory;

string folder = "MyDataBase";
string database = "Jujutsu-Kaisen.db";
string databaseFilePath = Path.Combine(baseDirectory, folder, database);
var connectionString = $"Data Source={databaseFilePath}";

//Sqlite
builder.Services.AddDbContext<ApplicationDB>(options => options.UseSqlite(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();