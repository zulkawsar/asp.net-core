using Games.Entities;
using Games.Repository;

namespace Games.Endpoints
{
   public static class GameEndpoints
   {
        public static RouteGroupBuilder MapGameEnpoint ( this IEndpointRouteBuilder route) {

            GameRepository gameRepository = new();

            var group = route.MapGroup("/games")
               .WithParameterValidation();

            group.MapGet("/", () => gameRepository.GetGames());

            group.MapGet("/{id}", (int id) => gameRepository.show(id));

            group.MapPost("/", (Game game) => gameRepository.create(game));

            group.MapPut("/{id}", (int id, Game gameUpdate) => gameRepository.update(id, gameUpdate));
            return group;
        } 
    }
}
