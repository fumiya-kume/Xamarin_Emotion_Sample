using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Common.Contract;
using Xamarin.Forms;
using Xamarin_Emotion_Sample;

namespace Xamarin_Emotion_Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var photoUrl = "";

            var imageChoiceResult = await DisplayAlert("画像の元を選択してください", "", "カメラ", "ギャラリー");

            try
            {
                if (imageChoiceResult)
                {
                    // 写真を撮影し、保存したURLを取得
                    photoUrl = await PhotoClient.TakePhoto();
                }
                else
                {
                    // 写真を撮影し、保存したURLを取得
                    photoUrl = await galleryClient.PickPhoto();

                }
            }
            catch (Exception exception)
            {
                await DisplayAlert("Error", exception.Message, "OK");
            }

            // 撮影した画像を表示
            ImagePreview.Source = photoUrl;

            EmotionScores emotionResult;
            try
            {
                // Cognitive Services - Emotion API を叩く
                emotionResult = await EmotionAPIClient.AnalyzeAsync(photoUrl);
            }
            catch (Exception exception)
            {
                await DisplayAlert("Error", exception.Message, "OK");
                return;
            }

            // 表示するためにビューにセットしていく
            Anger.Text = "怒り: " + Math.Round(emotionResult.Anger, 6).ToString("0.000000");
            Contempt.Text = "軽蔑: " + Math.Round(emotionResult.Contempt, 6).ToString("0.000000");
            Disgust.Text = "むかつき: " + Math.Round(emotionResult.Disgust, 6).ToString("0.000000");
            Fear.Text = "恐れ: " + Math.Round(emotionResult.Fear, 6).ToString("0.000000");
            Happiness.Text = "喜び: " + Math.Round(emotionResult.Happiness, 6).ToString("0.000000");
            Neutral.Text = "無表情: " + Math.Round(emotionResult.Neutral, 6).ToString("0.000000");
            Sadness.Text = "悲しみ: " + Math.Round(emotionResult.Sadness, 6).ToString("0.000000");
            Surprise.Text = "驚き: " + Math.Round(emotionResult.Surprise, 6).ToString("0.000000");
        }
    }
}
