// Add a timestamp comment indicating processing time at the top of the Markdown file.

// Processed on: 2026-10-01 10:00:00 UTC
using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);
            string htmlPath = Path.Combine(dataDir, "sample.html");
            string htmlContent = "<html><body><h1>Hello World</h1><p>This is a sample.</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Define output Markdown file
            string outputPath = Path.Combine(dataDir, "output.md");

            // Configure Markdown save options
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            options.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine("Markdown file saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}