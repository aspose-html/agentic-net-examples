// Batch convert HTML files to PDF with a progress callback to monitor conversion status.

using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "HTMLFiles");
                string outputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "PdfOutput");
                System.IO.Directory.CreateDirectory(inputFolder);
                System.IO.Directory.CreateDirectory(outputFolder);

                // Create a sample HTML file if none exist
                if (System.IO.Directory.GetFiles(inputFolder, "*.html").Length == 0)
                {
                    string samplePath = System.IO.Path.Combine(inputFolder, "sample1.html");
                    System.IO.File.WriteAllText(samplePath, "<html><body><h1>Sample HTML</h1></body></html>");
                }

                ConvertHtmlFiles(inputFolder, outputFolder);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void ConvertHtmlFiles(string inputFolder, string outputFolder)
        {
            string[] htmlFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");
            int total = htmlFiles.Length;
            int processed = 0;

            foreach (string htmlPath in htmlFiles)
            {
                processed++;
                System.Console.WriteLine($"Processing {processed}/{total}: {System.IO.Path.GetFileName(htmlPath)}");

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    string pdfFileName = System.IO.Path.ChangeExtension(System.IO.Path.GetFileName(htmlPath), ".pdf");
                    string pdfPath = System.IO.Path.Combine(outputFolder, pdfFileName);
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                }

                System.Console.WriteLine($"Converted to: {System.IO.Path.GetFileName(htmlPath)} -> {System.IO.Path.GetFileName(System.IO.Path.ChangeExtension(htmlPath, ".pdf"))}");
            }

            System.Console.WriteLine("Batch conversion completed.");
        }
    }
}