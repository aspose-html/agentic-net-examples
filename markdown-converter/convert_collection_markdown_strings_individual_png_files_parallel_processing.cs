// Convert a collection of Markdown strings to individual PNG files using parallel processing.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown strings
            List<string> markdowns = new List<string>
            {
                "# Title 1\n\nThis is the first markdown document.",
                "## Title 2\n\n* Item 1\n* Item 2",
                "### Title 3\n\n> A blockquote example."
            };

            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            Parallel.ForEach(
                markdowns,
                (md, state, index) =>
                {
                    // Convert markdown to HTML document
                    Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(md);

                    // Prepare image save options
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();

                    // Define output file path
                    string outputPath = Path.Combine(outputDir, $"output{index}.png");

                    // Convert HTML document to PNG
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}