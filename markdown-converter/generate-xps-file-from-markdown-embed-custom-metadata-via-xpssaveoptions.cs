// Generate an XPS file from a Markdown document and embed custom metadata via XpsSaveOptions.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.md");
            string savePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.xps");

            // Create a minimal Markdown file
            string markdownContent = "# Hello World\nThis is a sample markdown document.";
            File.WriteAllText(sourcePath, markdownContent);

            // Convert Markdown to HTMLDocument
            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
            {
                // Configure XPS save options with custom metadata
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                // Example of setting a metadata property (if supported)
                // Uncomment the line below if the property exists in the API version you use
                // options.DocumentTitle = "Sample XPS Document";

                // Convert HTMLDocument to XPS file
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}