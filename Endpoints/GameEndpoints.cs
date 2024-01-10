using Games.Dtos;
using Games.Entities;
using Games.Repository;

namespace Games.Endpoints
{
   public static class GameEndpoints
   {
        public static RouteGroupBuilder MapGameEnpoint(this IEndpointRouteBuilder route) {

            var GetGameEndpointName = "getGame";

            var group = route.MapGroup("/games")
               .WithParameterValidation();

            group.MapGet("/", async (IGameRepository gameRepository) =>
                (await gameRepository.GetGames()).Select(game => game.AsDtos())

            );

            group.MapGet("/{id}", async (IGameRepository gameRepository, int id) =>
            {
                Game? game = await gameRepository.show(id);
                return game is not null ? Results.Ok(game.AsDtos()) : Results.NotFound();
            }).WithName(GetGameEndpointName);

            group.MapPost("/", async (IGameRepository gameRepository, CreateGameDtos gameDto) => 
            {
                Game game = new()
                {
                    Name = gameDto.Name,
                    Genre = gameDto.Genre,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate

                };

                await gameRepository.create(game);
                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
            });

            group.MapPut("/{id}", (IGameRepository gameRepository, int id, Game gameUpdate) => gameRepository.update(id, gameUpdate));
            return group;
        } 
    }
}
