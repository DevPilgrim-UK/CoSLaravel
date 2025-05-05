namespace CampaignApp.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<PlayerQuest> PlayerQuests { get; set; }

    }
}
