# 🧠 Fake News Detection using ML.NET and ASP.NET Core 8

This project demonstrates how to detect fake news articles using machine learning in .NET. It includes:

- A model training console app using **ML.NET**
- A **Web API** built with **ASP.NET Core 8** to serve predictions in real time
- A sample dataset for training and testing

---

## 🚀 What It Does

- Accepts article `Title` and `Text`
- Predicts whether the article is **Real** or **Fake**
- Uses logistic regression trained on labeled data
- Exposes a REST API for integration into web apps or mobile apps

---

## 📁 Project Structure



FakeNewsDetection-MLNet-ASPNET/
│
├── FakeNewsTrainer/ # Console app to train the ML model
│ ├── fake_news_dataset.csv # Small sample training dataset
│ └── fakenews_model.zip # Saved trained model
│
├── FakeNewsDetectionAPI/ # ASP.NET Core Web API for predictions
│ ├── Controllers/
│ ├── Models/
│ ├── Services/
│ └── Program.cs
│
└── README.md


---

## 📄 Dataset Format (CSV)

```csv
Id,Title,Text,Label
1,"Breaking: Something happened","A news article goes here...",true
2,"Hoax Alert","This is totally made up",false
...


Label: true = real, false = fake

The model uses Title + Text combined for training

🛠 How to Run
✅ 1. Train the Model

Open FakeNewsTrainer in Visual Studio 2022

Make sure fake_news_dataset.csv is present

Run the project

It will generate fakenews_model.zip

✅ 2. Run the Web API

Open FakeNewsDetectionAPI in Visual Studio 2022

Ensure fakenews_model.zip is copied into the API project root

Run the API

Use Swagger/Postman to call /api/fakenews

🌐 Sample API Usage

POST /api/fakenews

Request:
{
  "Title": "Government Announces New Policy",
  "Text": "The new policy aims to improve healthcare."
}

Response:
{
  "prediction": true,
  "probability": 0.9471,
  "score": 3.812
}

🔍 Technologies Used

.NET 8

ML.NET

ASP.NET Core 8 Web API

Visual Studio 2022

📈 Future Improvements

Add evaluation metrics (accuracy, F1, AUC)

Expand dataset from Kaggle

Dockerize and deploy to cloud (Azure/AWS)

Add frontend (Blazor or React) for testing

🙌 Contributing

Pull requests and forks are welcome! Open an issue to discuss ideas or bugs.

📄 License

This project is licensed under the MIT License.
