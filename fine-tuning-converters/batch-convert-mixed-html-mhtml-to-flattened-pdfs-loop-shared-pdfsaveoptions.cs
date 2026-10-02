// Batch convert mixed HTML and MHTML files to flattened PDFs using a loop with shared PdfSaveOptions.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string sourceDir = "InputFiles";
            string outputDir = "OutputPdfs";

            // Ensure directories exist
            if (!Directory.Exists(sourceDir))
                Directory.CreateDirectory(sourceDir);
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Create sample HTML file
            string sampleHtmlPath = Path.Combine(sourceDir, "sample.html");
            if (!File.Exists(sampleHtmlPath))
                File.WriteAllText(sampleHtmlPath, "<html><body><h1>Sample HTML</h1><form><input type='text' name='field'/></form></body></html>");

            // Create sample MHTML file (simple placeholder)
            string sampleMhtmlPath = Path.Combine(sourceDir, "sample.mhtml");
            if (!File.Exists(sampleMhtmlPath))
                File.WriteAllText(sampleMhtmlPath, "<html><body><h1>Sample MHTML</h1><form><input type='text' name='field'/></form></body></html>");

            // Shared PDF save options with flattened form fields
            PdfSaveOptions sharedOptions = new PdfSaveOptions();
            sharedOptions.FormFieldBehaviour = FormFieldBehaviour.Flattened;

            // Process each file in the source directory
            string[] files = Directory.GetFiles(sourceDir);
            foreach (string filePath in files)
            {
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(filePath) + ".pdf");

                if (extension == ".html" || extension == ".htm")
                {
                    // Convert HTML file to PDF
                    HTMLDocument document = new HTMLDocument(filePath);
                    Aspose.Html.Converters.Converter.ConvertHTML(document, sharedOptions, outputPath);
                }
                else if (extension == ".mhtml" || extension == ".mht")
                {
                    // Convert MHTML file to PDF using a stream
                    using (Stream stream = File.OpenRead(filePath))
                    {
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, sharedOptions, outputPath);
                    }
                }
                else
                {
                    Console.WriteLine($"Unsupported file type: {filePath}");
                }
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}