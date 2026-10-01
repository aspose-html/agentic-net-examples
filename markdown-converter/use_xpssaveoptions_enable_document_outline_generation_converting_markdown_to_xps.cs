// Use XpsSaveOptions to enable document outline generation when converting Markdown to XPS.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "sample.md");
            string savePath = Path.Combine(Environment.CurrentDirectory, "output.xps");

            // Create a minimal Markdown file if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "# Sample Document\n\nThis is a *markdown* example.");
            }

            // Convert Markdown to HTMLDocument
            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
            {
                // Create XPS save options (default settings)
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                // Convert HTMLDocument to XPS
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            }

            Console.WriteLine("Conversion completed successfully. XPS saved to: " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}