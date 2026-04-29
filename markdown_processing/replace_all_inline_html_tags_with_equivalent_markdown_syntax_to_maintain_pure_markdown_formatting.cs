// Replace all inline HTML tags with equivalent Markdown syntax to maintain pure Markdown formatting.

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
            Converter.ConvertHTML(htmlPath, options, markdownPath);
            Console.WriteLine("Conversion completed. Markdown saved at " + markdownPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}