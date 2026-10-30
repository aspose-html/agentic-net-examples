// Load a Markdown file, convert it to HTML, and embed the HTML into an XPS document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string savePath = "output.xps";

            // Create a minimal markdown file if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "# Hello World\nThis is a sample markdown file.");
            }

            // Convert Markdown to HTMLDocument
            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
            {
                // Prepare XPS save options
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                // Convert HTMLDocument to XPS
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            }

            Console.WriteLine("Conversion completed. XPS saved at " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}