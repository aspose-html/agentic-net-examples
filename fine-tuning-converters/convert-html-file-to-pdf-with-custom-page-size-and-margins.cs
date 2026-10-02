// Convert an HTML file to PDF using PdfRenderingOptions to set custom page size and margins.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file
            string sourcePath = "sample.html";
            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);

            // Define custom page size (8.5 x 11 inches) and margins (1 inch on each side)
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5f),
                Aspose.Html.Drawing.Length.FromInches(11f));

            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(96, 96, 96, 96); // 96 points = 1 inch

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);

            // Set up PDF rendering options with the custom page layout
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = page;

            // Output PDF path
            string savePath = "output.pdf";

            // Render the document to PDF
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, savePath);
            document.RenderTo(device);

            // Clean up
            device.Dispose();
            document.Dispose();

            Console.WriteLine("PDF conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}