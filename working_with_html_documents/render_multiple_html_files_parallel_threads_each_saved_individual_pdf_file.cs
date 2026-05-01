// Render multiple HTML files in parallel threads, each saved as an individual PDF file.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Directory containing HTML files
            string inputDir = "InputHtml";

            // Get all HTML files in the directory
            string[] htmlFiles = Directory.GetFiles(inputDir, "*.html");

            // Process each file in parallel
            Parallel.ForEach(htmlFiles, htmlPath =>
            {
                // Create a configuration for the document
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

                // Load the HTML file into an HTMLDocument
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                {
                    // Determine the output PDF path
                    string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");

                    // Set PDF conversion options (default options)
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                    // Convert the HTML document to PDF and save to the output path
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                }
            });
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine(ex.Message);
        }
    }
}