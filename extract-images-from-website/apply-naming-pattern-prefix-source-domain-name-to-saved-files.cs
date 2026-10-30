// Apply a naming pattern that prefixes each saved file with the source domain name.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            // Input files (URLs)
            string[] inputs = new string[]
            {
                "https://example.com",
                "https://dotnet.microsoft.com"
            };

            for (int i = 0; i < inputs.Length; i++)
            {
                string inputPath = inputs[i];
                Uri uri = new Uri(inputPath);
                string host = string.IsNullOrEmpty(uri.Host) ? "local" : uri.Host;
                string pageName = Path.GetFileNameWithoutExtension(uri.AbsolutePath);
                if (string.IsNullOrEmpty(pageName))
                {
                    pageName = "index";
                }
                string outputFileName = $"{host}_{pageName}.jpg";
                string outputPath = Path.Combine(outputDir, outputFileName);

                using (var document = new Aspose.Html.HTMLDocument(inputPath, Directory.GetCurrentDirectory()))
                {
                    // Configure image options
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    // Convert
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }

                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}