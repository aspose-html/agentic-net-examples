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
            string baseUri = "about:blank";
            string expectedMarkdown = "# Hello World\n\nThis is a **test**.";

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            Console.WriteLine("Generated Markdown:");
            Console.WriteLine(markdown);

            if (markdown.Trim() == expectedMarkdown.Trim())
            {
                Console.WriteLine("Conversion succeeded and output matches expected.");
            }
            else
            {
                Console.WriteLine("Conversion output does not match expected.");
                Console.WriteLine("Expected Markdown:");
                Console.WriteLine(expectedMarkdown);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}