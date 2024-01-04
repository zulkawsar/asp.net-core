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

            group.MapGet("/", (IGameRepository gameRepository) =>
                gameRepository.GetGames().Select(game => game.AsDtos())

            );

            group.MapGet("/{id}", (IGameRepository gameRepository, int id) =>
            {
                Game? game = gameRepository.show(id);
                return game is not null ? Results.Ok(game.AsDtos()) : Results.NotFound();
            }).WithName(GetGameEndpointName);

            group.MapPost("/", (IGameRepository gameRepository, CreateGameDtos gameDto) => 
            {
                Game game = new()
                {
                    Name = gameDto.Name,
                    Genre = gameDto.Genre,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate

                };
                gameRepository.create(game);
                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
            });

            group.MapPut("/{id}", (IGameRepository gameRepository, int id, Game gameUpdate) => gameRepository.update(id, gameUpdate));
            return group;
        } 
    }
}
