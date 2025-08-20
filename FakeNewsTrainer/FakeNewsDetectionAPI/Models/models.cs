namespace FakeNewsDetectionAPI.Models
{
    public class NewsData
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    public class NewsDataProcessed
    {
        public string CombinedText { get; set; }
    }
    public class NewsPrediction
    {
        public bool Prediction { get; set; }
        public float Probability { get; set; }
        public float Score { get; set; }
    }

}
