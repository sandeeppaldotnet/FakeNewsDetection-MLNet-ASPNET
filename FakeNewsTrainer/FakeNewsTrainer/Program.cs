using FakeNewsTrainer;
using Microsoft.ML;

var mlContext = new MLContext();

// Load training data
var data = mlContext.Data.LoadFromTextFile<NewsData>(
    path: "fake_news_dataset.csv",
    hasHeader: true,
    separatorChar: ',');

// Combine Title + Text
var processedData = mlContext.Data.LoadFromEnumerable(
    mlContext.Data.CreateEnumerable<NewsData>(data, reuseRowObject: false)
        .Select(x => new NewsDataProcessed
        {
            CombinedText = $"{x.Title} {x.Text}",
            Label = x.Label
        }));

// Build pipeline
var pipeline = mlContext.Transforms.Text.FeaturizeText("Features", nameof(NewsDataProcessed.CombinedText))
    .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
        labelColumnName: nameof(NewsDataProcessed.Label),
        featureColumnName: "Features"));

// Train model
var model = pipeline.Fit(processedData);

// Save model
mlContext.Model.Save(model, processedData.Schema, "fakenews_model.zip");
Console.WriteLine("✅ Model trained and saved.");

// === TEST WITH SAMPLE DATA ===
var predictor = mlContext.Model.CreatePredictionEngine<NewsDataProcessed, NewsPrediction>(model);

// Example test input
var testSample = new NewsDataProcessed
{
    CombinedText = "Hoax Alert Hoax Alert"
};

var prediction = predictor.Predict(testSample);

Console.WriteLine("\n🔎 Test Prediction:");
Console.WriteLine($"Prediction: {(prediction.Prediction ? "Real" : "Fake")}");
Console.WriteLine($"Probability: {prediction.Probability:P2}");
Console.WriteLine($"Score: {prediction.Score:F4}");

public class NewsDataProcessed
{
    public string CombinedText { get; set; }
    public bool Label { get; set; }
}