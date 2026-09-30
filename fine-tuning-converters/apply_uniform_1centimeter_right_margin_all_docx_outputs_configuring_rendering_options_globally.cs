// Apply a uniform 1‑centimeter right margin to all DOCX outputs by configuring DocRenderingOptions globally.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1><p>This document has a right margin of 1 cm.</p></body></html>";
            // Create HTML document from string
            HTMLDocument document = new HTMLDocument(htmlContent);

            // Define page size (A4) in points
            Size pageSize = new Size(595, 842); // width, height

            // Define margins: left, top, right, bottom (in points). 1 cm ≈ 28 points
            Margin pageMargin = new Margin(0, 0, 28, 0);

            // Create page setup with the defined size and margin
            Page page = new Page(pageSize, pageMargin);

            // Configure DocSaveOptions with the page setup
            DocSaveOptions options = new DocSaveOptions();
            options.PageSetup.AnyPage = page;

            // Output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.docx");

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}