using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPalsApp.Classes
{
    public class ImagePicker
    {
        public static async Task<byte[]> PickPost()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.IsSupported)
            {
                return null;
            }
            var opt = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Small,
                CompressionQuality = 25
            };

            var img = await CrossMedia.Current.PickPhotoAsync(opt);

            if (img == null) return null;
            byte[] buf = new byte[img.GetStream().Length];

            img.GetStream().Read(buf, 0, buf.Length);
            if (buf.Length > ConnectionHelper.MAX_IMAGE_SIZE) return null;

            return buf;
        }
    }
}
