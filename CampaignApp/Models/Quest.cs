using System.ComponentModel.DataAnnotations;

namespace CampaignApp.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Difficulty { get; set; }

        // Foreign Key to Location
        public int LocationId { get; set; }
        public Location Location { get; set; }  

    }
}
