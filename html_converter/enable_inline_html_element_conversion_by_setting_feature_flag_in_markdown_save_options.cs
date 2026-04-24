// Enable inline HTML element conversion by setting the appropriate feature flag in MarkdownSaveOptions.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string markdownPath = "output.md";

            MarkdownSaveOptions options = new MarkdownSaveOptions();

            if (Enum.TryParse<MarkdownFeatures>("InlineHtml", out var inlineFeature))
            {
                options.Features |= inlineFeature;
            }

            Converter.ConvertHTML(htmlPath, options, markdownPath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}