// Write code to convert MHTML to GIF and then create an animated GIF sequence from multiple pages.

using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // ---------- Convert MHTML to GIF ----------
            string mhtmlPath = Path.Combine(outputDir, "sample.mht");
            // Create a minimal MHTML file (for demonstration)
            File.WriteAllText(mhtmlPath, "From: <saved by Aspose>\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\n\n------=_NextPart_000_0000\nContent-Type: text/html; charset=\"utf-8\"\n\n<html><body><h1>MHTML Sample</h1></body></html>\n------=_NextPart_000_0000--");

            using (System.IO.Stream mhtmlStream = System.IO.File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.ImageSaveOptions mhtmlOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                string mhtmlGifPath = Path.Combine(outputDir, "mhtml_converted.gif");
                Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, mhtmlOptions, mhtmlGifPath);
                Console.WriteLine($"MHTML converted to GIF: {mhtmlGifPath}");
            }

            // ---------- Convert multiple HTML pages to GIF frames ----------
            string[] htmlPages = { "page1.html", "page2.html", "page3.html" };
            string[] framePaths = new string[htmlPages.Length];

            for (int i = 0; i < htmlPages.Length; i++)
            {
                string htmlPath = Path.Combine(outputDir, htmlPages[i]);
                File.WriteAllText(htmlPath, $"<html><body><h2>Page {i + 1}</h2><p>This is page {i + 1}.</p></body></html>");

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Saving.ImageSaveOptions htmlOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                string framePath = Path.Combine(outputDir, $"frame{i + 1}.gif");
                Aspose.Html.Converters.Converter.ConvertHTML(document, htmlOptions, framePath);
                framePaths[i] = framePath;
                Console.WriteLine($"HTML page converted to GIF frame: {framePath}");
            }

            // ---------- Create animated GIF from frames ----------
            if (framePaths.Length > 0)
            {
                string animatedGifPath = Path.Combine(outputDir, "animated.gif");
                Image firstFrame = Image.FromFile(framePaths[0]);

                ImageCodecInfo gifEncoder = ImageCodecInfo.GetImageEncoders()
                    .First(codec => codec.FormatID == ImageFormat.Gif.Guid);

                Encoder encoder = Encoder.SaveFlag;
                EncoderParameters encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.MultiFrame);
                firstFrame.Save(animatedGifPath, gifEncoder, encoderParams);

                encoderParams.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.FrameDimensionTime);
                for (int i = 1; i < framePaths.Length; i++)
                {
                    using (Image frame = Image.FromFile(framePaths[i]))
                    {
                        firstFrame.SaveAdd(frame, encoderParams);
                    }
                }

                encoderParams.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.Flush);
                firstFrame.SaveAdd(encoderParams);
                firstFrame.Dispose();

                Console.WriteLine($"Animated GIF created: {animatedGifPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}