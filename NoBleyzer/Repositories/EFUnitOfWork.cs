using NoBleyzer.Interfaces;
using NoBleyzer.Models;

namespace NoBleyzer.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {

        private StoreContext db;
        private GameRepository gameRepository;

        public EFUnitOfWork(StoreContext context)
        {
            db = context;
        }

        public IRepository<Game> Games
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new GameRepository(db);
                return gameRepository;
            }
        }

        private bool disposed = false;

        public void Dispose()
        {
            if (!this.disposed)
            {
               
                db.Dispose();
                
                this.disposed = true;
            }
        }

        public void Save()
        {
            db.SaveChangesAsync();
        }
    }
}
