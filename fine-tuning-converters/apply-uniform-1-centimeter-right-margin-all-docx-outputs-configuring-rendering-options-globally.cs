// Apply a uniform 1‑centimeter right margin to all DOCX outputs by configuring DocRenderingOptions globally.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            // Load HTML from string (inline content)
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Create DOCX save options
            DocSaveOptions options = new DocSaveOptions();

            // Define page size (0 means default) and margin with 1 cm right margin
            Size pageSize = new Size(0, 0);
            Margin pageMargin = new Margin(0, 0, 1, 0); // left, top, right, bottom (centimeters)
            Page page = new Page(pageSize, pageMargin);

            // Apply the page setup globally for DOCX output
            options.PageSetup.AnyPage = page;

            // Output file path
            string outputPath = "output.docx";

            // Convert HTML to DOCX
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("DOCX file saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}