using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeNewsTrainer
{
    public class NewsData
    {
        [LoadColumn(1)] public string Title { get; set; }
        [LoadColumn(2)] public string Text { get; set; }
        [LoadColumn(3)] public bool Label { get; set; } // Real = true, Fake = false
    }

    public class NewsPrediction
    {
        [ColumnName("PredictedLabel")] public bool Prediction { get; set; }
        public float Probability { get; set; }
        public float Score { get; set; }
    }
}
