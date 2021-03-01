using GameTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTrack.Data
{
    public class SqlPlayerRepo : IPlayerRepo
    {
        private readonly GameTrackDbContext _context;

        public SqlPlayerRepo(GameTrackDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _context.Players.ToList();
        }

        public Player GetPlayer(int id)
        {
            return _context.Players.FirstOrDefault(p => p.Id == id);
        }

        public void CreatePlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            _context.Players.Add(player);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void DeletePlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            _context.Players.Remove(player);
        }

        public void UpdatePlayer(Player player)
        {
            
        }
    }
}
