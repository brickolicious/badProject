using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace BADProject.model
{
    class ImgConverter : IValueConverter
    {


        object IValueConverter.Convert(object value,Type targetType,object parameter,System.Globalization.CultureInfo culture)
        {
            if (value != null && value is byte[])
            {
                byte[] bytes = value as byte[];

                MemoryStream stream = new MemoryStream(bytes);

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();

                return image;
            }

            return null;
        }
        /*public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            MemoryStream ms = new MemoryStream((byte[])value);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        
        }*/

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            

            MemoryStream ms = new MemoryStream();
            Image img = (Image)value;
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}
