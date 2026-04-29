// Load a Markdown file, convert it to HTML, and embed the HTML into an XPS document.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source Markdown file
            string sourcePath = "input.md";

            // Path where the resulting XPS file will be saved
            string savePath = "output.xps";

            // (Optional) Markdown content variable – not used directly in conversion
            string code = "# Sample Markdown\n\nThis is a **test**.";

            // Convert the Markdown file to an HTMLDocument
            HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Create default XPS save options
            XpsSaveOptions options = new XpsSaveOptions();

            // Render the HTMLDocument to XPS and save it
            Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}