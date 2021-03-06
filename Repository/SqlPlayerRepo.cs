using GameTrack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTrack.Data.Repository
{

    public class SqlPlayerRepo : IPlayerRepo
    {
        private readonly GameTrackDbContext _context;

        public SqlPlayerRepo(GameTrackDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player> GetPlayer(string id)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.PlayerId.Equals(id));
        }


        public void CreatePlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }
            _context.Players.Add(player);
        }

        public void DeletePlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }
            _context.Players.Remove(player);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void UpdatePlayer(Player player)
        {
            
        }
    }
}
