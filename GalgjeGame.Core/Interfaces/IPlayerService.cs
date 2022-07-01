using GalgjeGame.Core.Entities;

namespace GalgjeGame.Core.Interfaces
{
    public interface IPlayerService
    {
        Task<Player> FindPlayer(string username);
    }
}