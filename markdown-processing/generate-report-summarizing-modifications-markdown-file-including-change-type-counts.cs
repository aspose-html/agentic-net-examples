// Generate a report summarizing all modifications made to a Markdown file, including counts of each change type.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            // Create original markdown file
            string originalPath = Path.Combine(outputDir, "original.md");
            string originalContent = "# Title\n\nThis is a paragraph.\n\n- Item 1\n- Item 2\n";
            File.WriteAllText(originalPath, originalContent);

            // Create modified markdown file
            string modifiedPath = Path.Combine(outputDir, "modified.md");
            string modifiedContent = "# Title\n\nThis is a paragraph.\n\n- Item 1\n- Item 2\n\n## New Section\n\nAdded a [link](https://example.com).\n\n![Alt](image.png)\n";
            File.WriteAllText(modifiedPath, modifiedContent);

            // Convert markdown files to HTML documents
            Aspose.Html.HTMLDocument originalDoc = Aspose.Html.Converters.Converter.ConvertMarkdown(originalPath);
            Aspose.Html.HTMLDocument modifiedDoc = Aspose.Html.Converters.Converter.ConvertMarkdown(modifiedPath);

            // Helper to count elements by tag name
            int CountElements(Aspose.Html.HTMLDocument doc, string tagName)
            {
                var collection = doc.GetElementsByTagName(tagName);
                return collection.Length;
            }

            // Count headings (h1-h6)
            int CountHeadings(Aspose.Html.HTMLDocument doc)
            {
                int total = 0;
                for (int i = 1; i <= 6; i++)
                {
                    total += CountElements(doc, "h" + i);
                }
                return total;
            }

            // Gather counts
            int originalHeadings = CountHeadings(originalDoc);
            int modifiedHeadings = CountHeadings(modifiedDoc);

            int originalLinks = CountElements(originalDoc, "a");
            int modifiedLinks = CountElements(modifiedDoc, "a");

            int originalImages = CountElements(originalDoc, "img");
            int modifiedImages = CountElements(modifiedDoc, "img");

            // Prepare report data
            var reportLines = new List<string>();
            reportLines.Add("ChangeType,OriginalCount,ModifiedCount,Difference");
            reportLines.Add($"Headings,{originalHeadings},{modifiedHeadings},{modifiedHeadings - originalHeadings}");
            reportLines.Add($"Links,{originalLinks},{modifiedLinks},{modifiedLinks - originalLinks}");
            reportLines.Add($"Images,{originalImages},{modifiedImages},{modifiedImages - originalImages}");

            // Write CSV report
            string reportPath = Path.Combine(outputDir, "ModificationReport.csv");
            using (StreamWriter writer = new StreamWriter(reportPath, false))
            {
                foreach (var line in reportLines)
                {
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine($"Report generated at: {reportPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}