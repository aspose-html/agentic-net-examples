// Convert a collection of Markdown strings to individual PNG files using parallel processing.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            List<string> markdowns = new List<string>
            {
                "# Title 1\nSome text.",
                "## Title 2\nMore text.",
                "# Title 3\nEven more."
            };

            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            Parallel.ForEach(Enumerable.Range(0, markdowns.Count), i =>
            {
                string md = markdowns[i];
                HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(md);
                ImageSaveOptions options = new ImageSaveOptions();
                string outputPath = Path.Combine(outputDir, $"output{i}.png");
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}