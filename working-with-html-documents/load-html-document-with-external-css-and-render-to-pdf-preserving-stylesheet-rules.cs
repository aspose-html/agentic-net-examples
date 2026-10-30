// Load an HTML document with external CSS and render it to PDF preserving stylesheet rules.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = "Output";
            System.IO.Directory.CreateDirectory(outputDir);

            string htmlPath = System.IO.Path.Combine(outputDir, "sample.html");
            string cssPath = System.IO.Path.Combine(outputDir, "style.css");
            string pdfPath = System.IO.Path.Combine(outputDir, "output.pdf");

            string cssContent = "body { font-family: Arial; color: #333; } h1 { color: #0066CC; }";
            System.IO.File.WriteAllText(cssPath, cssContent);

            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" type=\"text/css\" href=\"style.css\"></head><body><h1>Hello Aspose.HTML</h1><p>This PDF preserves external CSS styling.</p></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfPath))
            {
                document.RenderTo(device);
            }

            System.Console.WriteLine("PDF saved to: " + pdfPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}