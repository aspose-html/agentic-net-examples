// Implement asynchronous batch processing to convert thousands of HTML files to flattened PDFs without blocking the UI thread.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string inputFolder = @"C:\InputHtml";
            string outputFolder = @"C:\OutputPdf";
            Directory.CreateDirectory(outputFolder);

            var htmlFiles = Directory.GetFiles(inputFolder, "*.html");
            var tasks = htmlFiles.Select(htmlPath => Task.Run(() =>
            {
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");
                ConvertHtmlToFlattenedPdf(htmlPath, outputPath);
            }));

            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertHtmlToFlattenedPdf(string inputPath, string outputPath)
    {
        // Load HTML document
        HTMLDocument document = new HTMLDocument(inputPath);
        // Configure PDF options with flattening
        PdfSaveOptions options = new PdfSaveOptions();
        options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;
        // Perform conversion
        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
    }
}