using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPalsApp.Classes
{
    /// <summary>
    /// Clase que permite elegir una imagen
    /// del alacenamiento del teléfono.
    /// </summary>
    public class ImagePicker
    {
        /// <summary>
        /// Método que permite seleccionar
        /// una imagen de la galería. 
        /// </summary>
        /// <returns>La imagen seleccionada
        /// en formato array de bytes.</returns>
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
