// Escape special Markdown characters in all text nodes to prevent unintended formatting.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Title *with* markdown _characters_</h1><p>This is a paragraph with `code` and ~strikethrough~.</p></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();

            string tempPath = Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            // Escape markdown special characters
            string escaped = markdown
                .Replace("\\", "\\\\")
                .Replace("*", "\\*")
                .Replace("_", "\\_")
                .Replace("`", "\\`")
                .Replace("~", "\\~")
                .Replace("#", "\\#")
                .Replace("[", "\\[")
                .Replace("]", "\\]")
                .Replace(">", "\\>")
                .Replace("|", "\\|");

            string outputPath = "output.md";
            File.WriteAllText(outputPath, escaped);

            Console.WriteLine("Conversion completed. Markdown saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}