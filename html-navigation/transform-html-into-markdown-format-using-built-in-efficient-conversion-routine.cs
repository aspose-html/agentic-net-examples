// Transform the HTML into Markdown format using a built‑in efficient conversion routine.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1><p>This is a <a href=\"https://example.com\">link</a>.</p></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            options.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            string tempPath = System.IO.Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string markdown = System.IO.File.ReadAllText(tempPath);
            System.IO.File.Delete(tempPath);

            System.Console.WriteLine("Markdown output:");
            System.Console.WriteLine(markdown);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}