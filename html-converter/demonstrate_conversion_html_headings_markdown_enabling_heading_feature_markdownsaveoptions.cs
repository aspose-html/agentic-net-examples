// Demonstrate conversion of HTML headings to Markdown by enabling the Heading feature in MarkdownSaveOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<h1>Title</h1><h2>Subtitle</h2><p>Paragraph.</p>";
            string outputPath = "output.md";

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            options.Features = Aspose.Html.Saving.MarkdownFeatures.Link |
                               Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, options, outputPath);

            Console.WriteLine("Conversion completed. Markdown saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}