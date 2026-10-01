// Load an HTML document with external CSS and render it to PDF preserving stylesheet rules.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Define output directory and ensure it exists
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Create external CSS file
            string cssPath = Path.Combine(outputDir, "style.css");
            string cssContent = "body { font-family: Arial; color: blue; }";
            File.WriteAllText(cssPath, cssContent);

            // HTML content referencing the external CSS
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <link rel=""stylesheet"" type=""text/css"" href=""style.css"">
    <title>External CSS Example</title>
</head>
<body>
    <h1>Hello, Aspose.HTML!</h1>
    <p>This paragraph should be styled by the external CSS.</p>
</body>
</html>";

            // Base URI for resolving relative resources (the output directory)
            string baseUri = outputDir + Path.DirectorySeparatorChar;

            // Create HTMLDocument with content and base URI
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Save the HTML document to a file
            string htmlPath = Path.Combine(outputDir, "sample.html");
            document.Save(htmlPath);

            // Render the document to PDF
            string pdfPath = Path.Combine(outputDir, "sample.pdf");
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("HTML and PDF files have been generated successfully:");
            Console.WriteLine("HTML: " + htmlPath);
            Console.WriteLine("PDF: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}