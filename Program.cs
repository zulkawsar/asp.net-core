using Games.Endpoints;
using Games.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGameRepository, GameRepository>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGameEnpoint();

app.Run();
