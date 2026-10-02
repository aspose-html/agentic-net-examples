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
            var markdowns = new List<string>
            {
                "# Title 1\n\nThis is a **markdown** document.",
                "# Title 2\n\nAnother *markdown* content."
            };

            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            Parallel.ForEach(markdowns, (md, state, index) =>
            {
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(md);
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                string outputPath = Path.Combine(outputDir, $"output_{index}.png");
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}