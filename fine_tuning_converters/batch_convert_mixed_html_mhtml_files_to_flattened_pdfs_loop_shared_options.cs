// Batch convert mixed HTML and MHTML files to flattened PDFs using a loop with shared PdfSaveOptions.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output directories
            string inputFolder = "InputFiles";
            string outputFolder = "OutputPdfs";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Create shared PDF save options with form fields flattened
            PdfSaveOptions options = new PdfSaveOptions
            {
                FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened
            };

            // Process each file in the input folder
            foreach (string filePath in Directory.GetFiles(inputFolder))
            {
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                if (extension == ".mhtml" || extension == ".mht")
                {
                    // Convert MHTML to PDF using shared options
                    Aspose.Html.Converters.Converter.ConvertMHTML(filePath, options, outputPath);
                }
                else if (extension == ".html" || extension == ".htm")
                {
                    // Load HTML document from file
                    HTMLDocument document = new HTMLDocument(filePath);
                    // Convert HTML document to PDF using shared options
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
                else
                {
                    // Skip unsupported file types
                    continue;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}