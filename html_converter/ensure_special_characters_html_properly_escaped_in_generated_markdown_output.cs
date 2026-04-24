// Ensure that special characters in HTML are properly escaped in the generated Markdown output.

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
            string htmlContent = "<p>Hello & welcome to <strong>Aspose</strong>! Use <, >, &, \" characters.</p>";
            string baseUri = "http://example.com/";
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();
            Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);
            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);
            Console.WriteLine("Generated Markdown:");
            Console.WriteLine(markdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}