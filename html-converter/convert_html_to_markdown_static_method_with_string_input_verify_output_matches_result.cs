// Convert HTML to Markdown using the static method with string input and verify output matches expected result.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<h1>Hello World</h1><p>This is a <strong>test</strong>.</p>";
            string baseUri = "http://example.com/";
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);
            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            string expected = "# Hello World\n\nThis is a **test**.";
            bool isMatch = string.Equals(markdown.Trim(), expected.Trim(), StringComparison.Ordinal);
            Console.WriteLine("Generated Markdown:");
            Console.WriteLine(markdown);
            Console.WriteLine("Verification: " + (isMatch ? "Success" : "Failed"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}