// Convert Markdown emphasis markers from single asterisks to double asterisks for stronger emphasis.

using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content
            string markdown = "# Sample Document\nThis is *emphasized* text and this is *another example*.";

            // Replace single asterisk emphasis with double asterisks
            string pattern = @"\*(.+?)\*";
            string replacement = @"**$1**";
            string updatedMarkdown = Regex.Replace(markdown, pattern, replacement);

            // Define output path
            string outputPath = "updated.md";

            // Write the updated markdown to file
            File.WriteAllText(outputPath, updatedMarkdown);

            // Example usage of Aspose.Html API (MarkdownSaveOptions)
            MarkdownSaveOptions options = new MarkdownSaveOptions();

            Console.WriteLine($"Markdown emphasis conversion completed. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}