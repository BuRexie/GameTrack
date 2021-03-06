using GameTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTrack.Data.Repository
{
    public interface IPlayerRepo
    {
        Task<bool> SaveChanges();
        Task<IEnumerable<Player>> GetPlayers();
        Task<Player> GetPlayer(string id);
        void CreatePlayer(Player player);
        void UpdatePlayer(Player player);
        void DeletePlayer(Player player);
    }
}
