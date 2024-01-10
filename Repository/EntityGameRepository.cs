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

        public async Task<IEnumerable<Game>> GetGames()
        {
            return  await dbContext.Games.ToListAsync();
        }

        public async Task create(Game game)
        {

            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Game?> show(int id)
        {
            return await dbContext.Games.FindAsync(id);
        }

        public async Task update(int id, Game gameUpdate)
        {
            dbContext.Games.Update(gameUpdate);
            await dbContext.SaveChangesAsync();
        }
    }
}