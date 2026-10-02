// Convert a batch of HTML files to BMP images with custom page size using parallel processing.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output directories
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputHtml");
            Directory.CreateDirectory(inputFolder);
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "OutputBmp");
            Directory.CreateDirectory(outputFolder);

            // Create sample HTML files
            string sampleHtml1 = "<!DOCTYPE html><html><body><h1>Sample 1</h1></body></html>";
            string sampleHtml2 = "<!DOCTYPE html><html><body><h1>Sample 2</h1></body></html>";
            File.WriteAllText(Path.Combine(inputFolder, "sample1.html"), sampleHtml1);
            File.WriteAllText(Path.Combine(inputFolder, "sample2.html"), sampleHtml2);

            // Get all HTML files
            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");

            // Parallel conversion
            Parallel.ForEach(htmlFiles, htmlPath =>
            {
                using (var document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                    options.UseAntialiasing = false;
                    options.HorizontalResolution = 96;
                    options.VerticalResolution = 96;
                    options.BackgroundColor = System.Drawing.Color.Beige;
                    options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(800, 600),
                        new Aspose.Html.Drawing.Margin(10, 10, 10, 10));

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".bmp");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            });

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}