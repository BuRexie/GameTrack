using GameTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTrack.Data.Repository
{
    public interface IPlayerRepo
    {
        bool SaveChanges();
        IEnumerable<Player> GetPlayers();
        Player GetPlayer(int id);
        void CreatePlayer(Player player);
        void UpdatePlayer(Player player);
        void DeletePlayer(Player player);
    }
}
