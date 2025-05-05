using System.ComponentModel.DataAnnotations;

namespace CampaignApp.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string CharacterName { get; set; }
        [MaxLength(15)]
        public string Race { get; set; }
        [MaxLength(15)]
        public string Class { get; set; }
        [Range(1, 20)]
        public int Level { get; set; }
        public string? Notes { get; set; }

    }
}
