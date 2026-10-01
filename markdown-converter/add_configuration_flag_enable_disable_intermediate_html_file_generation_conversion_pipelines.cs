// Add a configuration flag to enable or disable intermediate HTML file generation during conversion pipelines.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Configuration flag to control intermediate HTML generation
            bool generateIntermediate = true;

            // Define file paths
            string sourcePath = "sample.md";
            string intermediateHtmlPath = "intermediate.html";
            string outputPdfPath = "output.pdf";

            // Ensure sample markdown file exists
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "# Sample Markdown\n\nThis is a *sample* markdown file.");
            }

            if (generateIntermediate)
            {
                // Convert Markdown to intermediate HTML file
                Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, intermediateHtmlPath);

                // Convert the intermediate HTML to PDF
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(intermediateHtmlPath, options, outputPdfPath);
            }
            else
            {
                // Direct conversion without saving intermediate HTML
                // Convert Markdown to HTML in memory and then to PDF
                // Load Markdown as HTMLDocument using a request (fallback to direct conversion)
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdfPath);
                document.Dispose();
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}