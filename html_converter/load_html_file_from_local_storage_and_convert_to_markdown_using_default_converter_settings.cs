// Load an HTML file from local storage and convert it to Markdown using default Converter settings.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace HtmlToMarkdown
{
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
                Console.WriteLine("Conversion completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}