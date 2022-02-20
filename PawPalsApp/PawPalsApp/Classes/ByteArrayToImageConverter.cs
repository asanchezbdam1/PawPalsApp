using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PawPalsApp.Classes
{
    /// <summary>
    /// Clase que convierte un array de
    /// bytes a imagen para uso en Xamarin.
    /// No reversible.
    /// </summary>
    public class ByteArrayToImageConverter : IValueConverter
    {
        /// <summary>
        /// Conversión del array de bytes pasado como parámetro.
        /// </summary>
        /// <param name="value">Array de bytes a convertir</param>
        /// <returns>Fuente de imagen convertida.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            var imageAsBytes = (byte[])value;
            return ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
