// Configure PdfSaveOptions to embed a custom JavaScript action that opens a URL when the PDF is opened.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a simple HTML file
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";
            File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1></body></html>");

            // Create PDF save options
            PdfSaveOptions pdfOptions = new PdfSaveOptions();
            // Embedding JavaScript is not supported in this version of Aspose.HTML, so this step is omitted.

            // Convert HTML to PDF
            Converter.ConvertHTML(htmlPath, pdfOptions, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}