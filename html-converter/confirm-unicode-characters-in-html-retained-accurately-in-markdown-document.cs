// Confirm that Unicode characters in HTML are retained accurately in the resulting Markdown document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"></head><body><p>Привет, мир! こんにちは世界 🌍</p></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();

            string tempPath = Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            Console.WriteLine("Markdown output:");
            Console.WriteLine(markdown);

            if (markdown.Contains("Привет") && markdown.Contains("こんにちは") && markdown.Contains("🌍"))
            {
                Console.WriteLine("Unicode characters retained.");
            }
            else
            {
                Console.WriteLine("Unicode characters missing!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}