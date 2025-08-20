using Microsoft.ML;

namespace FakeNewsDetectionAPI.Models
{
    public class PredictionService
    {
        private readonly PredictionEngine<NewsDataProcessed, NewsPrediction> _engine;

        public PredictionService()
        {
            var mlContext = new MLContext();

            // Load trained model
            var model = mlContext.Model.Load("fakenews_model.zip", out _);

            // Create prediction engine
            _engine = mlContext.Model.CreatePredictionEngine<NewsDataProcessed, NewsPrediction>(model);
        }

        public NewsPrediction Predict(NewsData input)
        {
            var combined = new NewsDataProcessed
            {
                CombinedText = $"{input.Title} {input.Text}"
            };

            return _engine.Predict(combined);
        }
    }
}
