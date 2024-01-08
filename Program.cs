using Games.Data;
using Games.Endpoints;
using Games.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGameRepository, GameRepository>();

var connString = builder.Configuration.GetConnectionString("GameConnection");

builder.Services.AddSqlServer<GameStoreContext>(connString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGameEnpoint();

app.Run();
