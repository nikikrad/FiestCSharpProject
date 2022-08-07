using Microsoft.EntityFrameworkCore;
using NoBleyzer.Interfaces;
using NoBleyzer.Models;

namespace NoBleyzer.Repositories
{
    public class GameRepository : IRepository<Game>
    {
        private StoreContext db;

        public GameRepository(StoreContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Game>> GetAsync()
        {
            return await db.Games.ToListAsync();
        }

        void IRepository<Game>.Create(Game item)
        {
            db.Games.Add(item);
        }

        void IRepository<Game>.Delete(int id)
        {
            Game game = new Game();
            if(game != null) 
                db.Games.Remove(game);
        }        
    }
}
