// Batch process MHTML newsletters, converting each to PDF with embedded fonts for consistent appearance.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output folders
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputMhtml");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "OutputPdf");
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample MHTML file if none exist
            string sampleMhtmlPath = Path.Combine(inputFolder, "sample.mhtml");
            if (!File.Exists(sampleMhtmlPath))
            {
                string mhtmlContent = "From: <Saved by WebKit>\r\nSubject: Sample\r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><h1>Hello MHTML</h1></body></html>\r\n------=_NextPart_000_0000--";
                File.WriteAllText(sampleMhtmlPath, mhtmlContent);
            }

            // Configure Aspose.HTML with fonts lookup folder
            Configuration configuration = new Configuration();
            IUserAgentService userAgentService = (IUserAgentService)configuration.GetService(typeof(IUserAgentService));
            userAgentService.FontsSettings.SetFontsLookupFolder(Environment.GetFolderPath(Environment.SpecialFolder.Fonts));

            // Process each MHTML file in the input folder
            string[] mhtmlFiles = Directory.GetFiles(inputFolder, "*.mhtml");
            foreach (string filePath in mhtmlFiles)
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(filePath) + ".pdf");
                    PdfSaveOptions pdfOptions = new PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
                }
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}