// Use XpsSaveOptions to set page size before converting a Markdown file to an XPS document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input markdown file and output XPS file paths
            string sourcePath = "sample.md";
            string outputPath = "output.xps";

            // Create a minimal markdown file if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "# Hello World\nThis is a test markdown file.");
            }

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Configure XPS save options with custom page size
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page();
            page.Size = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromPixels(800),
                Aspose.Html.Drawing.Length.FromPixels(600));
            // Optionally set margins (left, top, right, bottom) if needed
            // page.Margin = new Aspose.Html.Drawing.Margin(0, 0, 0, 0);

            options.PageSetup.AnyPage = page;

            // Perform the conversion to XPS
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}