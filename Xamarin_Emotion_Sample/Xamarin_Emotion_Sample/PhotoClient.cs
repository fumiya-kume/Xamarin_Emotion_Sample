using System;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace Xamarin_Emotion_Sample
{
    public static class PhotoClient
    {
        public static async Task<string> TakePhoto()
        {
            // カメラを初期化
            await CrossMedia.Current.Initialize();

            // カメラを使えるかどうか判定
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                throw new NotSupportedException("You should Set up camera");
            }

            // 撮影し、保存したファイルを取得
            var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());

            // 保存したファイルのパスを取得
            return photo.Path;
        }
    }
}
