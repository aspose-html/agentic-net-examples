// Apply a custom DPI of 200 when rendering HTML to PDF to improve image clarity.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string inputPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, PDF!</h1><img src='https://via.placeholder.com/150'></body></html>";
            System.IO.File.WriteAllText(inputPath, htmlContent);

            // Load HTML content and base URI
            string html = System.IO.File.ReadAllText(inputPath);
            string baseUri = new System.Uri(System.IO.Path.GetFullPath(inputPath)).AbsoluteUri;

            // Create HTML document from content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri);

            // Configure PDF save options with custom DPI
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;

            // Convert to PDF
            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}