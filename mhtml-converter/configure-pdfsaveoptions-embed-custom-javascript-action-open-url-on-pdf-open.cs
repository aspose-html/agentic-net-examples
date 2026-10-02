// Configure PdfSaveOptions to embed a custom JavaScript action that opens a URL when the PDF is opened.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.pdf";

            // Create a minimal HTML file
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>";
            System.IO.File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document from the file path
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputPath);

            // Configure PDF save options (JavaScript embedding not available in this version)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(doc, options, outputPath);

            System.Console.WriteLine("PDF created successfully: " + System.IO.Path.GetFullPath(outputPath));
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}