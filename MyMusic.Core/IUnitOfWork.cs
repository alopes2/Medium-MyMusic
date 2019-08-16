using System;
using System.Threading.Tasks;
using MyMusic.Core.Repositories;

namespace MyMusic.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository Musics { get; }
        IArtistRepository Artists { get; }
        Task<int> CommitAsync();
    }
}