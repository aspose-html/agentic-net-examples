// Create a document, add a link to external CSS, and ensure styles are applied after rendering.

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
            // HTML content referencing an external CSS file
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <link rel=""stylesheet"" href=""style.css"">
</head>
<body>
    <h1>Hello, World!</h1>
    <p>This text should be styled by the external CSS.</p>
</body>
</html>";

            // Base URI where the external CSS file is located
            string baseUri = Path.GetFullPath("Resources/");

            // Create HTMLDocument with content and base URI
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Save the HTML document to a file (optional, for verification)
            document.Save("output.html");

            // Render the HTML document to PDF, applying the external CSS styles
            PdfDevice pdfDevice = new PdfDevice("output.pdf");
            document.RenderTo(pdfDevice);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}