// Batch convert a set of HTML files to PDF, compressing images to reduce overall file size.

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
            // Prepare input and output directories
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputHtml");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "OutputPdf");
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create sample HTML files if none exist
            string sampleFile1 = Path.Combine(inputFolder, "sample1.html");
            if (!File.Exists(sampleFile1))
            {
                File.WriteAllText(sampleFile1, "<html><body><h1>Sample 1</h1><img src='https://via.placeholder.com/150'></body></html>");
            }

            string sampleFile2 = Path.Combine(inputFolder, "sample2.html");
            if (!File.Exists(sampleFile2))
            {
                File.WriteAllText(sampleFile2, "<html><body><h1>Sample 2</h1><p>Some text.</p></body></html>");
            }

            // Batch convert HTML files to PDF with image compression
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    PdfSaveOptions options = new PdfSaveOptions();
                    options.JpegQuality = 70; // compress JPEG images
                    options.HorizontalResolution = 150;
                    options.VerticalResolution = 150;

                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}