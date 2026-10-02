// Enable inline HTML element conversion by setting the appropriate feature flag in MarkdownSaveOptions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string savePath = "output.md";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello</h1><div><p>Paragraph with <span>inline HTML</span></p></div></body></html>");
            }

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            options.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, savePath);

            Console.WriteLine("Conversion completed. Markdown saved at " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}