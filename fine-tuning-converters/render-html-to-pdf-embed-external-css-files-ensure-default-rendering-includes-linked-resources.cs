// Render HTML to PDF and embed all external CSS files by ensuring default rendering includes linked resources.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input folder and files
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "input");
            Directory.CreateDirectory(inputFolder);

            string cssFile = Path.Combine(inputFolder, "style.css");
            File.WriteAllText(cssFile, "body { background-color: lightblue; } h1 { color: darkred; }");

            string htmlFile = Path.Combine(inputFolder, "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"style.css\"/></head><body><h1>Hello Aspose HTML</h1><p>This PDF includes external CSS.</p></body></html>";
            File.WriteAllText(htmlFile, htmlContent);

            // Load HTML document (file path constructor)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFile);

            // Define output PDF path
            string outputPdf = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Render HTML to PDF, embedding linked CSS
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdf))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + outputPdf);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}