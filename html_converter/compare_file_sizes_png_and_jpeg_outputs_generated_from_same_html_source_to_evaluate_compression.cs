// Compare file sizes of PNG and JPEG outputs generated from the same HTML source to evaluate compression.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace HtmlImageComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source HTML file
                string htmlPath = "sample.html";

                // Output image paths
                string pngPath = "output.png";
                string jpegPath = "output.jpg";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Convert to PNG
                ImageSaveOptions pngOptions = new ImageSaveOptions(ImageFormat.Png);
                Converter.ConvertHTML(document, pngOptions, pngPath);

                // Convert to JPEG
                ImageSaveOptions jpegOptions = new ImageSaveOptions(ImageFormat.Jpeg);
                Converter.ConvertHTML(document, jpegOptions, jpegPath);

                // Get file sizes
                long pngSize = new FileInfo(pngPath).Length;
                long jpegSize = new FileInfo(jpegPath).Length;

                // Output the comparison results
                Console.WriteLine($"PNG file size: {pngSize} bytes");
                Console.WriteLine($"JPEG file size: {jpegSize} bytes");
                Console.WriteLine(pngSize < jpegSize
                    ? "PNG is smaller."
                    : (pngSize > jpegSize ? "JPEG is smaller." : "Both files have the same size."));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}