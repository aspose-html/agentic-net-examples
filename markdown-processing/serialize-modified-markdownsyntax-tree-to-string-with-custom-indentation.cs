// Serialize the modified MarkdownSyntaxTree to a string with custom indentation for readability.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello</h1><p>Sample paragraph.</p></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            options.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            string tempPath = Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

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