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
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Write external CSS file
            string cssPath = Path.Combine(outputDir, "style.css");
            File.WriteAllText(cssPath, "h1 { color: blue; } p { font-size: 14px; }");

            // HTML content referencing the external CSS
            string htmlContent = "<html><head><link rel='stylesheet' href='style.css'></head><body><h1>Hello World</h1><p>This is a test.</p></body></html>";
            string baseUri = outputDir; // Base URI for resolving the CSS link

            // Output file paths
            string htmlPath = Path.Combine(outputDir, "document.html");
            string pdfPath = Path.Combine(outputDir, "document.pdf");

            // Load HTML document with base URI to resolve external CSS
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Save the original HTML file (optional)
            document.Save(htmlPath);

            // Render the HTML document to PDF preserving stylesheet rules
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfPath))
            {
                document.RenderTo(device);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}