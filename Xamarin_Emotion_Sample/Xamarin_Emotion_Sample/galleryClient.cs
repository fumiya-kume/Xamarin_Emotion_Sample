using System.Threading.Tasks;
using Plugin.Media;

namespace Xamarin_Emotion_Sample
{
    public static class galleryClient
    {
        public static async Task<string> PickPhoto()
        {
            // galleryから写真を選択させる
            var photo = await CrossMedia.Current.PickPhotoAsync();

            // 保存したファイルのパスを取得
            return photo.Path;
        }
    }
}
