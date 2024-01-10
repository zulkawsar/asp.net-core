using Games.Entities;

namespace Games.Repository
{
    public interface IGameRepository
    {
        Task create(Game game);
        Task<IEnumerable<Game>> GetGames();
        Task<Game?> show(int id);
        Task update(int id, Game gameUpdate);
    }
}