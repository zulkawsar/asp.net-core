using Games.Entities;

namespace Games.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly List<Game> games = new()
        {
            new Game()
            {
                Id = 1,
                Name = "Zul Kawsar",
                Genre = "Male",
                Price = 10,
                ReleaseDate = DateTime.Now,
            },
            new Game()
            {
                Id = 2,
                Name = "Kawsar",
                Genre = "Male",
                Price = 10,
                ReleaseDate = DateTime.Now,
            },
        };

        public IEnumerable<Game> GetGames()
        {
            return games;
        }

        public Game? show(int id)
        {
            return games.Find(game => game.Id == id);
        }

        public void create(Game game)
        {
            game.Id = games.Max(game => game.Id) + 1;
            games.Add(game);
        }

        public void update(int id, Game gameUpdate)
        {
            var GameIndex = games.FindIndex(game => game.Id == id);
            gameUpdate.Id = id;
            games[GameIndex] = gameUpdate;

        }

    }
}
