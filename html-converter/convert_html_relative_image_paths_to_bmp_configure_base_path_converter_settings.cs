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
            // Prepare directories
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create a sample image (PNG)
            string imagePath = Path.Combine(inputDir, "image.png");
            using (Bitmap bmp = new Bitmap(100, 100))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Red);
                }
                bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
            }

            // Create HTML with relative image path
            string htmlContent = "<html><body><h1>Sample</h1><img src=\"image.png\"/></body></html>";
            string htmlPath = Path.Combine(inputDir, "sample.html");
            File.WriteAllText(htmlPath, htmlContent);

            // Load HTML document (base path is the file location)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Set image save options to BMP
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

            // Convert HTML to BMP
            string outputPath = Path.Combine(outputDir, "output.bmp");
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}