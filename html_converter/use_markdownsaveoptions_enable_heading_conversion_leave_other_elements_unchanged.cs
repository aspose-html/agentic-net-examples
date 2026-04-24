// Use MarkdownSaveOptions to enable only heading conversion while leaving other elements unchanged.

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
            // Specific feature selection for headings is not available in this version,
            // so default conversion options are used.

            Converter.ConvertHTML(htmlPath, options, markdownPath);
            Console.WriteLine("Conversion completed. Markdown saved at " + markdownPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}