using GalgjeGame.Core.Entities;

namespace GalgjeGame.Core.Interfaces
{
    public interface IPlayerStatsService
    {
        Task<IEnumerable<PlayerStats>> GetTop10Scores();
        Task<IEnumerable<PlayerStats>> GetTop10Players();
    }
}