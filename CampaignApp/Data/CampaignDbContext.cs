using Microsoft.EntityFrameworkCore;
using CampaignApp.Models;

namespace CampaignApp.Data
{
    public class CampaignAppDbContext : DbContext
    {
        public CampaignAppDbContext(DbContextOptions<CampaignAppDbContext> options)
            : base(options) { }

        public DbSet<Npc> Npcs { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Player> Players { get; set; }

    }
}
