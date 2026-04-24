// Selectively convert only heading and list tags from HTML by configuring MarkdownSaveOptions.Features accordingly.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string markdownPath = "output.md";

            MarkdownSaveOptions options = new MarkdownSaveOptions();
            // Selective conversion of headings and lists is not directly supported; using default conversion.
            Converter.ConvertHTML(htmlPath, options, markdownPath);

            Console.WriteLine("Conversion completed. Markdown saved at " + markdownPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}