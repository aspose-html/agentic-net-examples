// Create a document, add a link to external CSS, and ensure styles are applied after rendering.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string cssPath = Path.Combine(Directory.GetCurrentDirectory(), "styles.css");
            File.WriteAllText(cssPath, "body { background-color: lightblue; } h1 { color: darkred; }");

            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"styles.css\"/></head><body><h1>Hello World</h1></body></html>";

            string baseUri = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            string htmlOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(htmlOutputPath);

            string pdfOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfOutputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}