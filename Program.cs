using Games.Data;
using Games.Endpoints;
using Games.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();
app.Services.InitializeDb();

app.MapGet("/", () => "Hello World!");
app.MapGameEnpoint();

app.Run();
