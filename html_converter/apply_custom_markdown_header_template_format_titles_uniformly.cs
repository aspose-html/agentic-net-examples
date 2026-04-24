// Apply a custom Markdown header template via MarkdownSaveOptions.Template to format document titles uniformly.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source HTML file
                string htmlPath = "input.html";

                // Desired output Markdown file path
                string markdownPath = "output.md";

                // Initialize Markdown save options
                MarkdownSaveOptions options = new MarkdownSaveOptions();

                // If the API supported a Template property, it would be set here.
                // Since MarkdownSaveOptions does not have a Template property, this step is skipped.

                // Convert the HTML document to Markdown using the specified options
                Converter.ConvertHTML(htmlPath, options, markdownPath);

                Console.WriteLine("HTML successfully converted to Markdown at: " + markdownPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}