// Selectively convert only heading and list tags from HTML by configuring MarkdownSaveOptions.Features accordingly.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string htmlContent = "<html><head><title>Test</title></head><body><h1>Heading 1</h1><p>Paragraph.</p><ul><li>Item 1</li><li>Item 2</li></ul><h2>Heading 2</h2></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            string savePath = "output.md";

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            options.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, savePath);

            string markdown = File.ReadAllText(savePath);
            Console.WriteLine("Converted Markdown:");
            Console.WriteLine(markdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}