// Escape special Markdown characters in all text nodes to prevent unintended formatting.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello *World*</h1></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();

            string tempPath = Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            string outputPath = "output.md";
            File.WriteAllText(outputPath, markdown);

            Console.WriteLine("Conversion completed. Markdown saved at " + outputPath);
            Console.WriteLine("Markdown content:");
            Console.WriteLine(markdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}