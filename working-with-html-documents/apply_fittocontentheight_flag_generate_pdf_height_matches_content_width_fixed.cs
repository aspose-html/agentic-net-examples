// Apply FitToContentHeight flag only, generating a PDF where height matches content but width stays fixed.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
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
    <p>This PDF was generated from HTML using Aspose.HTML for .NET.</p>
</body>
</html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                // Configure PDF rendering options
                Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                options.PageSetup.PageLayoutOptions = Aspose.Html.Rendering.PageLayoutOptions.FitToContentWidth |
                                                      Aspose.Html.Rendering.PageLayoutOptions.FitToContentHeight;

                // Define margins (0.5 inches on each side)
                double leftInches = 0.5;
                double topInches = 0.5;
                double rightInches = 0.5;
                double bottomInches = 0.5;

                Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                    Aspose.Html.Drawing.Length.FromInches(topInches),
                    Aspose.Html.Drawing.Length.FromInches(rightInches),
                    Aspose.Html.Drawing.Length.FromInches(bottomInches),
                    Aspose.Html.Drawing.Length.FromInches(leftInches));

                // Define page size (8.5 x 11 inches)
                Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5),
                    Aspose.Html.Drawing.Length.FromInches(11));

                // Create a page with the size and margins
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margin);
                options.PageSetup.AnyPage = page;

                // Render the document to PDF
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath))
                {
                    document.RenderTo(device);
                }
            }

            Console.WriteLine("PDF successfully generated at: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("An error occurred: " + ex.Message);
        }
    }
}