// Batch convert a mixed collection of HTML and MHTML files to PDF, preserving original filenames.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputFiles";
            string outputFolder = "OutputPdfs";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            string sampleHtmlPath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(sampleHtmlPath))
            {
                File.WriteAllText(sampleHtmlPath, "<html><body><h1>Hello HTML</h1></body></html>");
            }

            string sampleMhtmlPath = Path.Combine(inputFolder, "sample.mhtml");
            if (!File.Exists(sampleMhtmlPath))
            {
                string mhtmlContent = "From: <Saved by WebKit>\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\n\n------=_NextPart_000_0000\nContent-Type: text/html; charset=\"utf-8\"\n\n<html><body><h1>Hello MHTML</h1></body></html>\n------=_NextPart_000_0000--";
                File.WriteAllText(sampleMhtmlPath, mhtmlContent);
            }

            foreach (string filePath in Directory.GetFiles(inputFolder))
            {
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(filePath) + ".pdf");

                if (extension == ".html" || extension == ".htm")
                {
                    using (HTMLDocument document = new HTMLDocument(filePath))
                    {
                        PdfSaveOptions options = new PdfSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    }
                    Console.WriteLine($"Converted HTML: {Path.GetFileName(filePath)} -> {Path.GetFileName(outputPath)}");
                }
                else if (extension == ".mhtml" || extension == ".mht")
                {
                    using (FileStream stream = File.OpenRead(filePath))
                    {
                        PdfSaveOptions options = new PdfSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    }
                    Console.WriteLine($"Converted MHTML: {Path.GetFileName(filePath)} -> {Path.GetFileName(outputPath)}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}