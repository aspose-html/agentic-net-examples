// Transform the HTML into Markdown format using a built‑in efficient conversion routine.

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
                // Path to the source HTML file
                string htmlPath = "input.html";

                // Path where the resulting Markdown file will be saved
                string savePath = "output.md";

                // Default options for Markdown conversion
                MarkdownSaveOptions options = new MarkdownSaveOptions();

                // Perform the conversion from HTML to Markdown
                Converter.ConvertHTML(htmlPath, options, savePath);

                Console.WriteLine("Conversion completed. Markdown saved at " + savePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}