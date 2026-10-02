// Create a document, add a link to external CSS, and ensure styles are applied after rendering.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare output folder
            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);

            // Create external CSS file
            string cssPath = Path.Combine(outputFolder, "style.css");
            File.WriteAllText(cssPath, "body { background-color: lightblue; } h1 { color: red; }");

            // HTML content linking to the external CSS
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"style.css\" /></head><body><h1>Hello World</h1></body></html>";

            // Base URI pointing to the folder containing the CSS
            string baseUri = new Uri(Path.GetFullPath(outputFolder) + Path.DirectorySeparatorChar).AbsoluteUri;

            // Create the HTML document
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Render the document to PDF
            string pdfPath = Path.Combine(outputFolder, "result.pdf");
            using (PdfDevice device = new PdfDevice(pdfPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated at: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}