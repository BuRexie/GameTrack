using GameTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTrack.Data
{
    public class GameTrackDbContext : DbContext
    {
      public GameTrackDbContext(DbContextOptions<GameTrackDbContext> opt) : base(opt)
      {

      }

      public DbSet<Player> Players { get; set; }
  }
}
