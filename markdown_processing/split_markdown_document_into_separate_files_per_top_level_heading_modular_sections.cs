// Split a Markdown document into separate files for each top‑level heading to create modular sections.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.md";
            string outputFolder = "output";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Convert the markdown file to an HTMLDocument
            HTMLDocument htmlDoc = Converter.ConvertMarkdown(inputPath);

            // Get all top‑level headings (h1)
            var headings = htmlDoc.QuerySelectorAll("h1");

            for (int i = 0; i < headings.Length; i++)
            {
                HTMLElement heading = (HTMLElement)headings[i];
                StringBuilder segmentBuilder = new StringBuilder();

                // Collect the heading and all following sibling nodes until the next h1
                Node current = heading;
                while (current != null)
                {
                    // Stop before the next h1 (but not the first heading itself)
                    if (current != heading && current is HTMLElement elem && elem.TagName.Equals("h1", StringComparison.OrdinalIgnoreCase))
                        break;

                    segmentBuilder.Append(((Element)current).OuterHTML);
                    current = current.NextSibling;
                }

                // Create a new HTMLDocument for the segment
                HTMLDocument segmentDoc = new HTMLDocument();
                segmentDoc.Body.InnerHTML = segmentBuilder.ToString();

                // Prepare markdown save options
                MarkdownSaveOptions options = new MarkdownSaveOptions();

                // Build a safe file name from the heading text
                string safeTitle = heading.TextContent.Trim()
                    .Replace(' ', '_')
                    .Replace(Path.GetInvalidFileNameChars(), "_");
                string outPath = Path.Combine(outputFolder, $"{safeTitle}.md");

                // Convert the HTML segment to a markdown file
                Converter.ConvertHTML(segmentDoc, options, outPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

static class PathExtensions
{
    public static string Replace(this string str, char[] chars, string replacement)
    {
        foreach (var c in chars)
            str = str.Replace(c.ToString(), replacement);
        return str;
    }
}