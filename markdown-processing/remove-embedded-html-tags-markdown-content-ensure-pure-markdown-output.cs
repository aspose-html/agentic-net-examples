// Remove any embedded HTML tags from the Markdown content to ensure pure Markdown output.

using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello</h1><p>This is <b>bold</b> text.</p></body></html>";
            string baseUri = "about:blank";
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);
            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);
            string cleanedMarkdown = Regex.Replace(markdown, "<.*?>", string.Empty);
            Console.WriteLine("Original Markdown:");
            Console.WriteLine(markdown);
            Console.WriteLine("Cleaned Markdown:");
            Console.WriteLine(cleanedMarkdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}