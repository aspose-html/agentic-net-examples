// Render HTML to PDF and embed all external CSS files by ensuring default rendering includes linked resources.

class Program
{
    static void Main()
    {
        try
        {
            // Determine working directory
            string currentDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string htmlPath = System.IO.Path.Combine(currentDir, "sample.html");
            string cssPath = System.IO.Path.Combine(currentDir, "style.css");
            string pdfPath = System.IO.Path.Combine(currentDir, "output.pdf");

            // Create a simple CSS file
            System.IO.File.WriteAllText(cssPath, "body { font-family: Arial; color: blue; }");

            // Create an HTML file that links the CSS
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" type=\"text/css\" href=\"style.css\"></head><body><h1>Hello, Aspose.HTML!</h1><p>This is a sample paragraph.</p></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document with base URL to resolve linked resources
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, currentDir);

            // Render the document to PDF, embedding external CSS
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfPath))
            {
                document.RenderTo(device);
            }

            System.Console.WriteLine("PDF generated successfully at: " + pdfPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}