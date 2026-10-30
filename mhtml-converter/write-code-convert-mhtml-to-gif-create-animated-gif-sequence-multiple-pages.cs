// Write code to convert MHTML to GIF and then create an animated GIF sequence from multiple pages.

using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);

            // -------------------------------------------------
            // Convert MHTML to GIF
            // -------------------------------------------------
            string mhtmlPath = "sample.mhtml";
            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(mhtmlPath))
            {
                File.WriteAllText(mhtmlPath, @"MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0012_01D4C3E0.5A6B2C90""

------=_NextPart_000_0012_01D4C3E0.5A6B2C90
Content-Type: text/html; charset=""utf-8""

<html><body><h1>MHTML Sample</h1></body></html>

------=_NextPart_000_0012_01D4C3E0.5A6B2C90--");
            }

            string mhtmlGifPath = Path.Combine(outputFolder, "mhtml.gif");
            using (System.IO.Stream mhtmlStream = System.IO.File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.ImageSaveOptions mhtmlOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, mhtmlOptions, mhtmlGifPath);
            }
            Console.WriteLine($"MHTML converted to GIF: {mhtmlGifPath}");

            // -------------------------------------------------
            // Create sample HTML pages
            // -------------------------------------------------
            string[] htmlPages = {
                Path.Combine(outputFolder, "page1.html"),
                Path.Combine(outputFolder, "page2.html"),
                Path.Combine(outputFolder, "page3.html")
            };
            string[] htmlContents = {
                "<html><body style=\"background:#ffdddd;\"><h1>Page 1</h1></body></html>",
                "<html><body style=\"background:#ddffdd;\"><h1>Page 2</h1></body></html>",
                "<html><body style=\"background:#ddddff;\"><h1>Page 3</h1></body></html>"
            };
            for (int i = 0; i < htmlPages.Length; i++)
            {
                File.WriteAllText(htmlPages[i], htmlContents[i]);
            }

            // -------------------------------------------------
            // Convert each HTML page to a GIF frame
            // -------------------------------------------------
            List<string> framePaths = new List<string>();
            for (int i = 0; i < htmlPages.Length; i++)
            {
                Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlPages[i]);
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                string framePath = Path.Combine(outputFolder, $"frame{i}.gif");
                Aspose.Html.Converters.Converter.ConvertHTML(doc, options, framePath);
                framePaths.Add(framePath);
                Console.WriteLine($"HTML page converted to GIF frame: {framePath}");
            }

            // -------------------------------------------------
            // Combine frames into an animated GIF
            // -------------------------------------------------
            string animatedGifPath = Path.Combine(outputFolder, "animated.gif");
            if (framePaths.Count > 0)
            {
                using (Image first = Image.FromFile(framePaths[0]))
                {
                    ImageCodecInfo gifEncoder = ImageCodecInfo.GetImageEncoders()
                        .First(c => c.MimeType == "image/gif");
                    EncoderParameters encoderParams = new EncoderParameters(1);
                    encoderParams.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
                    first.Save(animatedGifPath, gifEncoder, encoderParams);

                    for (int i = 1; i < framePaths.Count; i++)
                    {
                        using (Image frame = Image.FromFile(framePaths[i]))
                        {
                            encoderParams.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.FrameDimensionTime);
                            first.SaveAdd(frame, encoderParams);
                        }
                    }

                    encoderParams.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.Flush);
                    first.SaveAdd(encoderParams);
                }
                Console.WriteLine($"Animated GIF created: {animatedGifPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}