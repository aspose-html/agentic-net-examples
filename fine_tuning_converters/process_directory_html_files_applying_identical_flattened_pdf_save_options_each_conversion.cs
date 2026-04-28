// Process a directory of HTML files, applying identical flattened PdfSaveOptions for each conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output directories
            string inputFolder = "InputHtml";
            string outputFolder = "OutputPdf";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Process each HTML file in the input folder
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Configure PDF save options to flatten form fields
                    PdfSaveOptions options = new PdfSaveOptions();
                    options.FormFieldBehaviour = FormFieldBehaviour.Flattened;

                    // Determine the output PDF file path
                    string outputPath = Path.Combine(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");

                    // Convert HTML to PDF with the specified options
                    Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}