// Convert HTML containing relative image paths to BMP by configuring the base path in Converter settings.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with a relative image path
            string htmlContent = "<html><body><img src=\"images/pic.png\" /></body></html>";

            // Define base directory for HTML and images
            string baseDir = Path.Combine(Directory.GetCurrentDirectory(), "html");
            string imagesDir = Path.Combine(baseDir, "images");
            Directory.CreateDirectory(imagesDir);

            // Create a sample image file (PNG) in the images folder
            string imagePath = Path.Combine(imagesDir, "pic.png");
            using (Bitmap bmp = new Bitmap(100, 100))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Red);
                }
                bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
            }

            // Construct a base URI for the HTML document (file scheme)
            string baseUri = new Uri(baseDir + Path.DirectorySeparatorChar).AbsoluteUri;

            // Load HTML document with base URI to resolve relative image paths
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Set image save options to BMP format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

            // Define output BMP file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.bmp");

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}