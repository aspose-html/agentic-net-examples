// Transform the HTML into Markdown format using a built‑in efficient conversion routine.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string markdownPath = "output.md";

            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1><p>This is a <a href=\"https://example.com\">link</a>.</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            options.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, markdownPath);

            Console.WriteLine("Conversion completed. Markdown saved at " + markdownPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}