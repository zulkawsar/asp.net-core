using Games.Dtos;
using Games.Entities;

namespace Games.Endpoints
{
    public static class EntityExtension
    {
        public static GameDtos AsDtos(this Game game)
        {
            return new GameDtos(
                game.Id,
                game.Name,
                game.Genre,
                game.Price,
                game.ReleaseDate
            );

        }
    }
}
