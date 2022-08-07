using NoBleyzer.Models;

namespace NoBleyzer.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Game> Games { get; }
        //IRepository<Player> Players { get; }
        //IRepository<PC> PCs { get; }
        //IRepository<OS> OSs { get; }
        void Save();
    }
}
