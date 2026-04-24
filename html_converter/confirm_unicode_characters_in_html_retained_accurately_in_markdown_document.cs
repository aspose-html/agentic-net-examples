// Confirm that Unicode characters in HTML are retained accurately in the resulting Markdown document.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<p>Unicode test: 測試, 😊, Привет</p>";
            string baseUri = "http://example.com/";
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();
            Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);
            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);
            bool containsAll = markdown.Contains("測試") && markdown.Contains("😊") && markdown.Contains("Привет");
            Console.WriteLine(containsAll ? "Unicode characters retained." : "Unicode characters missing.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}