using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFrame.Common.Helper
{
    public class ImageHelper
    {
        public static void ConvertTypeToJPEG(string File)
        {
            using (Image source = Image.FromFile(File))
            {
                ImageCodecInfo codec = ImageCodecInfo.GetImageEncoders().First(c => c.MimeType == "image/jpeg");

                EncoderParameters parameters = new EncoderParameters(3);
                parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                parameters.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.ScanMethod, (int)EncoderValue.ScanMethodInterlaced);
                parameters.Param[2] = new EncoderParameter(System.Drawing.Imaging.Encoder.RenderMethod, (int)EncoderValue.RenderProgressive);
                source.Save(@"D:\temp\saved.jpg", codec, parameters);
            }
        }
    }
}
