using Games.Entities;
using Games.Repository;

namespace Games.Endpoints
{
   public static class GameEndpoints
   {
        public static RouteGroupBuilder MapGameEnpoint ( this IEndpointRouteBuilder route) {


            var group = route.MapGroup("/games")
               .WithParameterValidation();

            group.MapGet("/", (IGameRepository gameRepository) => gameRepository.GetGames());

            group.MapGet("/{id}", (IGameRepository gameRepository, int id) => gameRepository.show(id));

            group.MapPost("/", (IGameRepository gameRepository, Game game) => gameRepository.create(game));

            group.MapPut("/{id}", (IGameRepository gameRepository, int id, Game gameUpdate) => gameRepository.update(id, gameUpdate));
            return group;
        } 
    }
}
