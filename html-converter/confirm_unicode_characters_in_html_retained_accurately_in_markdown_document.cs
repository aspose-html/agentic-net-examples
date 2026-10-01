// Confirm that Unicode characters in HTML are retained accurately in the resulting Markdown document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<p>Unicode test: 測試, тест, اختبار, 😊</p>";
            string baseUri = "";
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            Console.WriteLine("Generated Markdown:");
            Console.WriteLine(markdown);

            bool allPresent = markdown.Contains("測試") && markdown.Contains("тест") && markdown.Contains("اختبار") && markdown.Contains("😊");
            Console.WriteLine();
            Console.WriteLine(allPresent ? "All Unicode characters are retained." : "Unicode characters are missing.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}