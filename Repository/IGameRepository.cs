using Games.Entities;

namespace Games.Repository
{
    public interface IGameRepository
    {
        void create(Game game);
        IEnumerable<Game> GetGames();
        Game? show(int id);
        void update(int id, Game gameUpdate);
    }
}