// Log detailed conversion progress and errors to a file for troubleshooting batch operations.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        // Input directory containing HTML files
        string inputDir = "input";
        // Output directory for generated PDFs
        string outputDir = "output";
        // Log file path for progress and error details
        string logPath = "conversion.log";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all .html and .htm files recursively
            string[] htmlFiles = Directory.GetFiles(inputDir, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(inputDir, "*.htm", SearchOption.AllDirectories);

            int total = htmlFiles.Length;

            // Process each HTML file
            for (int i = 0; i < total; i++)
            {
                string htmlPath = htmlFiles[i];
                // Build corresponding PDF path in the output folder
                string pdfFileName = Path.ChangeExtension(Path.GetFileName(htmlPath), ".pdf");
                string pdfPath = Path.Combine(outputDir, pdfFileName);

                try
                {
                    // Load the HTML document
                    using (HTMLDocument document = new HTMLDocument(htmlPath))
                    {
                        // Configure PDF conversion options (default options used here)
                        PdfSaveOptions options = new PdfSaveOptions();

                        // Perform the conversion
                        Converter.ConvertHTML(document, options, pdfPath);
                    }

                    // Log successful conversion
                    string successMessage = $"[{DateTime.Now}] Converted {Path.GetFileName(htmlPath)} to {pdfFileName} ({i + 1}/{total})";
                    File.AppendAllText(logPath, successMessage + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    // Log conversion error for the current file
                    string errorMessage = $"[{DateTime.Now}] Error converting {Path.GetFileName(htmlPath)}: {ex.Message}";
                    File.AppendAllText(logPath, errorMessage + Environment.NewLine);
                }
            }
        }
        catch (Exception ex)
        {
            // Log any fatal errors that prevent the batch from starting
            string fatalMessage = $"[{DateTime.Now}] Fatal error: {ex.Message}";
            File.AppendAllText(logPath, fatalMessage + Environment.NewLine);
        }
    }
}