// Write code to convert MHTML to GIF and then create an animated GIF sequence from multiple pages.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using System.Drawing;
using System.Drawing.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string[] mhtmlFiles = { "page1.mhtml", "page2.mhtml", "page3.mhtml" };
            List<Image> frames = new List<Image>();
            foreach (string filePath in mhtmlFiles)
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    string tempGifPath = Path.GetTempFileName();
                    ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                    Converter.ConvertMHTML(stream, options, tempGifPath);
                    Image img = Image.FromFile(tempGifPath);
                    frames.Add(img);
                }
            }

            if (frames.Count > 0)
            {
                string animatedGifPath = "animated.gif";
                Image firstFrame = frames[0];
                Encoder encoder = Encoder.SaveFlag;
                EncoderParameters encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.MultiFrame);
                ImageCodecInfo gifCodec = GetEncoderInfo("image/gif");
                firstFrame.Save(animatedGifPath, gifCodec, encoderParams);

                encoderParams.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.FrameDimensionTime);
                for (int i = 1; i < frames.Count; i++)
                {
                    firstFrame.SaveAdd(frames[i], encoderParams);
                }

                encoderParams.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.Flush);
                firstFrame.SaveAdd(encoderParams);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.MimeType.Equals(mimeType, StringComparison.OrdinalIgnoreCase))
                return codec;
        }
        return null;
    }
}