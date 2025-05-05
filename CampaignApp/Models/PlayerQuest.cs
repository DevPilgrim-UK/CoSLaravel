namespace CampaignApp.Models
{
    public class PlayerQuest
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int QuestId { get; set; }
        public Quest Quest { get; set; }
    }
}
