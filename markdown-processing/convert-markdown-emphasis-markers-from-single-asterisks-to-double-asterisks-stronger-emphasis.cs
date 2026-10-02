// Convert Markdown emphasis markers from single asterisks to double asterisks for stronger emphasis.

using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string inputPath = "sample.md";
            string modifiedPath = "modified.md";
            string htmlOutputPath = "output.html";

            // Create a sample markdown file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "This is *emphasized* text with *multiple* markers.");
            }

            // Read the original markdown content
            string markdown = File.ReadAllText(inputPath);

            // Replace single asterisk emphasis with double asterisks
            string pattern = @"\*(.+?)\*";
            string replaced = Regex.Replace(markdown, pattern, @"**$1**");

            // Save the modified markdown
            File.WriteAllText(modifiedPath, replaced);

            // Convert the modified markdown to HTML using Aspose.Html
            Aspose.Html.Converters.Converter.ConvertMarkdown(modifiedPath, htmlOutputPath);

            Console.WriteLine("Markdown emphasis conversion completed successfully.");
            Console.WriteLine($"Modified markdown saved to: {modifiedPath}");
            Console.WriteLine($"HTML output saved to: {htmlOutputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}