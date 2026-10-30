// Batch convert HTML files to PDF, naming each output file with the original filename plus a suffix.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputPdf";
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            if (Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<html><body><h1>Sample</h1></body></html>");
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    PdfSaveOptions options = new PdfSaveOptions();
                    string outputPath = Path.Combine(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + "_converted.pdf"
                    );
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    Console.WriteLine($"Converted '{htmlPath}' to '{outputPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}