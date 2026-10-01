// Apply FitToWidestContentWidth flag to ensure PDF page width matches the widest element in HTML.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output PDF paths
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>Sample Document</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 0; padding: 20px; }
        h1 { color: #2E8B57; }
    </style>
</head>
<body>
    <h1>Hello, Aspose.HTML!</h1>
    <p>This PDF was generated from a simple HTML file.</p>
</body>
</html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure PDF rendering options
            var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            // Define margins (0.5 inches on each side)
            var margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0.5), // left
                Aspose.Html.Drawing.Length.FromInches(0.5), // top
                Aspose.Html.Drawing.Length.FromInches(0.5), // right
                Aspose.Html.Drawing.Length.FromInches(0.5)  // bottom
            );

            // Define page size (A4: 595x842 points)
            var size = new Aspose.Html.Drawing.Size(595, 842);
            var page = new Aspose.Html.Drawing.Page(size, margin);

            // Apply page settings
            options.PageSetup.AnyPage = page;
            options.PageSetup.PageLayoutOptions = Aspose.Html.Rendering.PageLayoutOptions.FitToContentWidth |
                                                  Aspose.Html.Rendering.PageLayoutOptions.FitToContentHeight;

            // Render the document to PDF
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"PDF successfully created at: {Path.GetFullPath(pdfPath)}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}