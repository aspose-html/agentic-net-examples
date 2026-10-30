// Configure ImageSaveOptions to set background transparency for PNG output when source MHTML contains transparent elements.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "MIME-Version: 1.0\r\n" +
                    "Content-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n" +
                    "------=_NextPart_000_0000\r\n" +
                    "Content-Type: text/html; charset=\"utf-8\"\r\n\r\n" +
                    "<html><body><div style=\"width:100px;height:100px;background:rgba(255,0,0,0.5);\"></div></body></html>\r\n" +
                    "------=_NextPart_000_0000--");
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                options.BackgroundColor = System.Drawing.Color.Transparent;
                options.UseAntialiasing = true;

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("PNG image saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}