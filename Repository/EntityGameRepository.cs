using Games.Data;
using Games.Entities;
using Microsoft.EntityFrameworkCore;

namespace Games.Repository
{
    public class EntityGameRepository : IGameRepository
    {
        private readonly GameStoreContext dbContext;

        public EntityGameRepository(GameStoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Game> GetGames()
        {
            return dbContext.Games.ToList();
        }

        public void create(Game game)
        {

            dbContext.Games.Add(game);
            dbContext.SaveChanges();
        }

        public Game? show(int id)
        {
            return dbContext.Games.Find(id);
        }

        public void update(int id, Game gameUpdate)
        {
            dbContext.Games.Update(gameUpdate);
            dbContext.SaveChanges();
        }
    }
}