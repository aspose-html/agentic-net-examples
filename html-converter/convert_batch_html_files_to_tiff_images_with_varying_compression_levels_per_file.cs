// Convert a batch of HTML files to TIFF images while applying different compression levels per file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output directories
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "input");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create sample HTML files
            string htmlFile1 = Path.Combine(inputFolder, "sample1.html");
            string htmlFile2 = Path.Combine(inputFolder, "sample2.html");
            File.WriteAllText(htmlFile1, "<html><body><h1>First Sample</h1></body></html>");
            File.WriteAllText(htmlFile2, "<html><body><h1>Second Sample</h1></body></html>");

            int index = 0;
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    // Apply different compression levels per file
                    if (index == 0)
                    {
                        // First file: no compression
                        options.Compression = Aspose.Html.Rendering.Image.Compression.None;
                    }
                    // Second file: default compression (no explicit setting)

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".tiff");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
                index++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}