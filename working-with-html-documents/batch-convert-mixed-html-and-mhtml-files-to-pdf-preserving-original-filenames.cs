// Batch convert a mixed collection of HTML and MHTML files to PDF, preserving original filenames.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "InputFiles";
            string outputDir = "OutputFiles";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create a sample HTML file if it does not exist
            string sampleHtmlPath = Path.Combine(inputDir, "sample.html");
            if (!File.Exists(sampleHtmlPath))
            {
                File.WriteAllText(sampleHtmlPath, "<html><body><h1>Sample HTML</h1></body></html>");
            }

            // Create a sample MHTML file if it does not exist (minimal placeholder)
            string sampleMhtmlPath = Path.Combine(inputDir, "sample.mhtml");
            if (!File.Exists(sampleMhtmlPath))
            {
                string mhtmlContent = "From: <Saved by WebKit>\nSubject: Sample MHTML\nDate: Thu, 1 Jan 1970 00:00:00 GMT\nMIME-Version: 1.0\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\n\n------=_NextPart_000_0000\nContent-Type: text/html; charset=\"utf-8\"\nContent-Transfer-Encoding: quoted-printable\n\n<html><body><h1>Sample MHTML</h1></body></html>\n------=_NextPart_000_0000--";
                File.WriteAllText(sampleMhtmlPath, mhtmlContent);
            }

            string[] files = Directory.GetFiles(inputDir);
            foreach (string filePath in files)
            {
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(filePath) + ".pdf");

                if (extension == ".html" || extension == ".htm")
                {
                    Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(filePath);
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
                else if (extension == ".mhtml" || extension == ".mht")
                {
                    using (FileStream stream = File.OpenRead(filePath))
                    {
                        Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    }
                }
                else
                {
                    Console.WriteLine($"Skipping unsupported file: {filePath}");
                }
            }

            Console.WriteLine("Batch conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}