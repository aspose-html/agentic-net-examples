// Convert HTML to Markdown using the static method with string input and verify output matches expected result.

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
            string htmlContent = "<h1>Hello World</h1><p>This is a paragraph.</p>";
            string baseUri = "";
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();
            Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);
            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);
            string expected = "# Hello World\n\nThis is a paragraph.\n";
            if (markdown == expected)
                Console.WriteLine("Conversion successful and output matches expected result.");
            else
                Console.WriteLine("Conversion completed but output does not match expected result.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}