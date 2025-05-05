using System.ComponentModel.DataAnnotations;

namespace CampaignApp.Models
{
    public class Npc
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Affinity { get; set; }

        public bool Met { get; set; }
        public int LocationId { get; set; }
    }
}
