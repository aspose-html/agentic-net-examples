// Provide an option to overwrite existing files or skip them based on a user‑defined flag.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputHtml");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "OutputPdf");
            bool overwriteExisting = false; // set to true to overwrite existing PDFs

            // Ensure folders exist
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string[] existingHtml = Directory.GetFiles(inputFolder, "*.html");
            if (existingHtml.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                string sampleContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(samplePath, sampleContent);
            }

            ConvertHtmlFilesInFolder(inputFolder, outputFolder, overwriteExisting);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertHtmlFilesInFolder(string inputFolder, string outputFolder, bool overwrite)
    {
        string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
        foreach (string htmlPath in htmlFiles)
        {
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(htmlPath);
            string pdfPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

            if (File.Exists(pdfPath) && !overwrite)
            {
                Console.WriteLine($"Skipping existing file: {pdfPath}");
                continue;
            }

            // Load HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Set PDF save options (default options are sufficient for this example)
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, pdfPath);

            Console.WriteLine($"Converted '{htmlPath}' to '{pdfPath}'.");
        }
    }
}