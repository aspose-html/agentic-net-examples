// Batch convert HTML files to PDF with a progress callback to monitor conversion status.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Folder containing HTML files
            string inputFolder = "input_html";
            // Folder where PDF files will be saved
            string outputFolder = "output_pdf";
            Directory.CreateDirectory(outputFolder);

            // Get all HTML files in the input folder
            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
            int totalFiles = htmlFiles.Length;

            for (int i = 0; i < totalFiles; i++)
            {
                string htmlPath = htmlFiles[i];
                string pdfPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");

                // Report progress
                Console.WriteLine($"Converting ({i + 1}/{totalFiles}): {Path.GetFileName(htmlPath)}");

                // Create configuration and PDF options
                Configuration config = new Configuration();
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert HTML file to PDF
                Converter.ConvertHTML(htmlPath, config, options, pdfPath);
            }

            Console.WriteLine("Batch conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}