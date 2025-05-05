using Microsoft.EntityFrameworkCore;
using CampaignApp.Models;
using Microsoft.AspNetCore.Http.Features;

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
        public DbSet<Item> Items { get; set; }
        public DbSet<PlayerQuest> PlayerQuests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerQuest>()
                .HasKey(pq => new { pq.PlayerId, pq.QuestId });

            modelBuilder.Entity<PlayerQuest>()
                .HasOne(pq => pq.Player)
                .WithMany(p => p.PlayerQuests)
                .HasForeignKey(pq => pq.PlayerId);

            modelBuilder.Entity<PlayerQuest>()
                .HasOne(pq => pq.Quest)
                .WithMany(q => q.PlayerQuests)
                .HasForeignKey(pq => pq.QuestId);
        }
    }


}
