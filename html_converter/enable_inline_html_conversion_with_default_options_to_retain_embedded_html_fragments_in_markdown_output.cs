// Enable inline HTML conversion together with default options to retain embedded HTML fragments in the Markdown output.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file containing inline HTML fragments
            string htmlPath = "input.html";

            // Path where the resulting Markdown file will be saved
            string markdownPath = "output.md";

            // Create default Markdown save options (retain inline HTML by default)
            MarkdownSaveOptions options = new MarkdownSaveOptions();

            // Convert HTML to Markdown using the default options
            Converter.ConvertHTML(htmlPath, options, markdownPath);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}