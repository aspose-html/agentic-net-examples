// Compare file sizes of PNG and JPEG outputs generated from the same HTML source to evaluate compression.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string pngPath = "sample.png";
            string jpegPath = "sample.jpg";

            // Create a minimal HTML file
            File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1></body></html>");

            // Convert to PNG
            Aspose.Html.Saving.ImageSaveOptions pngOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, pngOptions, pngPath);

            // Convert to JPEG
            Aspose.Html.Saving.ImageSaveOptions jpegOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, jpegOptions, jpegPath);

            long pngSize = new FileInfo(pngPath).Length;
            long jpegSize = new FileInfo(jpegPath).Length;

            if (pngSize > jpegSize)
            {
                Console.WriteLine("JPEG is smaller than PNG.");
            }
            else if (pngSize < jpegSize)
            {
                Console.WriteLine("PNG is smaller than JPEG.");
            }
            else
            {
                Console.WriteLine("PNG and JPEG have the same size.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}