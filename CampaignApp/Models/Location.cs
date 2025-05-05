using System.ComponentModel.DataAnnotations;

namespace CampaignApp.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }

        public ICollection<Npc> Npcs { get; set; }  // Navigation property (one-to-many)
        public ICollection<Quest> Quests { get; set; }  // Navigation property (one-to-many)
    }
}
