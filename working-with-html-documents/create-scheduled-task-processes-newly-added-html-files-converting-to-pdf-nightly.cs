// Create a scheduled task that processes newly added HTML files, converting them to PDF nightly.

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
            string inputDir = "InputHtml";
            string outputDir = "OutputPdf";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            string samplePath = Path.Combine(inputDir, "sample.html");
            if (!File.Exists(samplePath))
            {
                File.WriteAllText(samplePath, "<html><body><h1>Sample</h1><p>This is a sample HTML file.</p></body></html>");
            }

            ConvertHtmlFilesInFolder(inputDir, outputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ConvertHtmlFilesInFolder(string inputDir, string outputDir)
    {
        foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
        {
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                string pdfFileName = Path.GetFileNameWithoutExtension(htmlPath) + ".pdf";
                string pdfPath = Path.Combine(outputDir, pdfFileName);

                PdfSaveOptions options = new PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

                Console.WriteLine($"Converted '{htmlPath}' to '{pdfPath}'.");
            }
        }
    }
}