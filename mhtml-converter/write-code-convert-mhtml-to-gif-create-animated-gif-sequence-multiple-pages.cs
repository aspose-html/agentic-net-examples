// Write code to convert MHTML to GIF and then create an animated GIF sequence from multiple pages.

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample MHTML file
            string mhtmlPath = "sample.mhtml";
            string mhtmlContent = @"From: <Saved by Windows Internet Explorer>
Subject: 
Date: 
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello MHTML</h1></body></html>
------=_NextPart_000_0000--";
            File.WriteAllText(mhtmlPath, mhtmlContent);

            // Convert MHTML to GIF
            string mhtmlGifPath = "mhtml_output.gif";
            using (Stream mhtmlStream = File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, options, mhtmlGifPath);
            }

            // Prepare sample HTML pages
            string htmlPath1 = "page1.html";
            string htmlPath2 = "page2.html";
            File.WriteAllText(htmlPath1, "<html><body><h2>Page 1</h2></body></html>");
            File.WriteAllText(htmlPath2, "<html><body><h2>Page 2</h2></body></html>");

            // Convert HTML pages to GIFs
            string gifPath1 = "page1.gif";
            string gifPath2 = "page2.gif";

            Aspose.Html.Saving.ImageSaveOptions htmlOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

            Aspose.Html.HTMLDocument doc1 = new Aspose.Html.HTMLDocument(Path.GetFullPath(htmlPath1));
            Aspose.Html.Converters.Converter.ConvertHTML(doc1, htmlOptions, gifPath1);

            Aspose.Html.HTMLDocument doc2 = new Aspose.Html.HTMLDocument(Path.GetFullPath(htmlPath2));
            Aspose.Html.Converters.Converter.ConvertHTML(doc2, htmlOptions, gifPath2);

            // Create animated GIF from the generated GIFs
            List<Image> frames = new List<Image>
            {
                Image.FromFile(mhtmlGifPath),
                Image.FromFile(gifPath1),
                Image.FromFile(gifPath2)
            };

            string animatedGifPath = "animated_output.gif";
            Encoder encoder = Encoder.SaveFlag;
            EncoderParameters encoderParams = new EncoderParameters(1);
            ImageCodecInfo gifCodec = GetEncoderInfo("image/gif");

            // First frame
            encoderParams.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.MultiFrame);
            frames[0].Save(animatedGifPath, gifCodec, encoderParams);

            // Subsequent frames
            for (int i = 1; i < frames.Count; i++)
            {
                encoderParams.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.FrameDimensionTime);
                frames[0].SaveAdd(frames[i], encoderParams);
            }

            // Flush
            encoderParams.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.Flush);
            frames[0].SaveAdd(encoderParams);

            // Cleanup
            foreach (var img in frames)
            {
                img.Dispose();
            }

            Console.WriteLine("Conversion and animation completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        return ImageCodecInfo.GetImageEncoders().FirstOrDefault(codec => codec.MimeType.Equals(mimeType, StringComparison.OrdinalIgnoreCase));
    }
}