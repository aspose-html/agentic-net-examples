// Use MarkdownSaveOptions to enable only heading conversion while leaving other elements unchanged.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Sample Heading</h1><p>This is a paragraph.</p><a href='https://example.com'>Example Link</a></body></html>";
            string baseUri = "about:blank";

            string tempPath = Path.GetTempFileName();

            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = (MarkdownFeatures)0; // Enable only heading conversion (no other features)

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            Console.WriteLine("Markdown output:");
            Console.WriteLine(markdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}