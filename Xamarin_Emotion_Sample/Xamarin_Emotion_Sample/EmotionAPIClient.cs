using System.Threading.Tasks;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Emotion;
using PCLStorage;

namespace Xamarin_Emotion_Sample
{
    public static class EmotionAPIClient
    {
        // ここに Emotion API のsubscribeキーを入力してください
        private static readonly string SubscribeKey = "";

        public static async Task<EmotionScores> AnalyzeAsync(string PhotoURL)
        {
            var client = new EmotionServiceClient(SubscribeKey);
            var file = await FileSystem.Current.GetFileFromPathAsync(PhotoURL);
            var ImageStream = await file.OpenAsync(FileAccess.Read);
            var result = await client.RecognizeAsync(ImageStream);
            return result[0].Scores;
        }
    }
}
