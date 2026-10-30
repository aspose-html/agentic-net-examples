// Configure PdfSaveOptions to set a custom PDF version number for compatibility with older readers.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a simple HTML file as input
            string inputPath = "sample.html";
            System.IO.File.WriteAllText(inputPath, "<html><body><h1>Hello PDF</h1></body></html>");

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Configure PDF save options (PDF version property is not available in the API)
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            pdfOptions.HorizontalResolution = 300;
            pdfOptions.VerticalResolution = 300;

            // Convert HTML to PDF
            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);

            Console.WriteLine("PDF saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}