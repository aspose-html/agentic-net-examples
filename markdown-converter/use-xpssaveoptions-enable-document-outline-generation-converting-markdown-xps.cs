// Use XpsSaveOptions to enable document outline generation when converting Markdown to XPS.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = "sample.md";
            string savePath = "output.xps";

            // Create a minimal Markdown file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string markdownContent = "# Sample Document\n\nThis is a **Markdown** document converted to XPS.\n\n- Item 1\n- Item 2\n";
                File.WriteAllText(sourcePath, markdownContent);
            }

            // Convert Markdown to HTMLDocument
            using (HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
            {
                // Configure XPS save options (outline generation is enabled by default if supported)
                XpsSaveOptions options = new XpsSaveOptions();

                // Convert HTMLDocument to XPS file
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            }

            Console.WriteLine("Conversion completed successfully. XPS saved to: " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}