// Render HTML to PDF and embed all external CSS files by ensuring default rendering includes linked resources.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string htmlPath = Path.Combine(baseDir, "sample.html");
            string cssPath = Path.Combine(baseDir, "style.css");
            string pdfPath = Path.Combine(baseDir, "output.pdf");

            // Create sample CSS file
            File.WriteAllText(cssPath, "body { font-family: Arial; color: blue; } h1 { color: red; }");

            // Create sample HTML that links the CSS file
            string htmlContent = $"<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"{Path.GetFileName(cssPath)}\"></head><body><h1>Hello World</h1><p>This is a test.</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load HTML document (file path ensures linked resources are resolved)
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Render HTML to PDF
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}