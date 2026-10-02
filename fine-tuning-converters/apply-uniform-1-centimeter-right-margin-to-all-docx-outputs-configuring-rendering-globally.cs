// Apply a uniform 1‑centimeter right margin to all DOCX outputs by configuring DocRenderingOptions globally.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string inputHtmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            File.WriteAllText(inputHtmlPath, htmlContent);

            // Output DOCX file path
            string outputDocxPath = "output.docx";

            // Load HTML document from file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath);

            // Define page size (A4: 595x842 points) and margin (1 cm right margin ≈ 28 points)
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(595, 842);
            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(0, 0, 28, 0);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);

            // Configure DOCX saving options
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
            options.PageSetup.AnyPage = page;

            // Convert HTML to DOCX with the specified options
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputDocxPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + Path.GetFullPath(outputDocxPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}