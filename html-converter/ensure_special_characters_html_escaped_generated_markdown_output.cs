// Ensure that special characters in HTML are properly escaped in the generated Markdown output.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample &amp; Test</title></head><body><h1>Hello, World!</h1><p>This is a paragraph with special characters: &lt; &gt; &amp; \" '</p></body></html>";
            string baseUri = "http://example.com/";
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            Console.WriteLine("Converted Markdown:");
            Console.WriteLine(markdown);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}